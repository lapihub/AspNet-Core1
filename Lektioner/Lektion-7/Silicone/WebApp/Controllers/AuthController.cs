using Infrastructure.Entities;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    #region SignUp

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                string roleName = "User";

                if (!await _userManager.Users.AnyAsync()) 
                    roleName = "Admin";

                if (!await _userManager.Users.AnyAsync(x => x.Email == model.Email))
                {
                    var appUser = UserFactory.Create(model.FirstName, model.LastName, model.Email);

                    if((await _userManager.CreateAsync(appUser, model.Password)).Succeeded)
                    {
                        await _userManager.AddToRoleAsync(appUser, roleName);

                        if ((await _signInManager.PasswordSignInAsync(appUser.Email!, model.Password, false, false)).Succeeded)
                            return LocalRedirect("/");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "User with the same email address already exists";
                }
            } 
            catch 
            {
                ViewData["StatusMessage"] = "An unexpected error occurred. Please try again.";
            }
        }

        return View(model);
    }


    #endregion

    #region SignIn

    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }


    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false)).Succeeded)
                    return LocalRedirect("/");
            }
            catch
            {
                ViewData["StatusMessage"] = "An unexpected error occurred. Please try again.";
            }
        }

        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(model);
    }

    #endregion

    #region Sign Out

    [HttpGet]
    [Route("/signout")]

    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }

    #endregion
}