using Infrastructure.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountService(UserManager<UserEntity> userManager, DataContext context, IConfiguration configuration)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;


    public async Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal)
    {
        var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userEntity = await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifer);
        if (userEntity != null)
        {
            return UserFactory.Create(userEntity!);
        }
        return null!;
    }

    public async Task<bool> UpdateBasicInfoAsync(ClaimsPrincipal claimsPrincipal, AccountBasicInfo basicInfo)
    {
        try
        {
            var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == nameIdentifer);
            if (userEntity != null)
            {
                userEntity.FirstName = basicInfo.FirstName;
                userEntity.LastName = basicInfo.LastName;
                userEntity.PhoneNumber = basicInfo.PhoneNumber;
                userEntity.Bio = basicInfo.Biography;

                _context.Update(userEntity);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex) { }
        return false;
    }

    public async Task<bool> UpdateAddressInfoAsync(ClaimsPrincipal claimsPrincipal, AccountAddressInfo addressInfo)
    {
        try
        {
            var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifer);
            if (userEntity!.Address != null)
            {
                userEntity.Address!.AddressLine_1 = addressInfo.AddressLine_1;
                userEntity.Address!.AddressLine_2 = addressInfo.AddressLine_2;
                userEntity.Address!.PostalCode = addressInfo.PostalCode;
                userEntity.Address!.City = addressInfo.City;
            }
            else
            {
                userEntity.Address = new AddressEntity
                {
                    AddressLine_1 = addressInfo.AddressLine_1,
                    AddressLine_2 = addressInfo.AddressLine_2,
                    PostalCode = addressInfo.PostalCode,
                    City = addressInfo.City,
                };
            }

            _context.Update(userEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex) { }
        return false;
    }


    public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0)
            {
                var user = await _userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FilePath:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfileImage = fileName;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return false;
    }



}