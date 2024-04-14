using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Middlewares;

public class AuthMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        if (await userManager.GetUserAsync(context.User) == null)
        {
            signInManager.SignOutAsync().Wait();
        }

        await _next(context);
    }
}