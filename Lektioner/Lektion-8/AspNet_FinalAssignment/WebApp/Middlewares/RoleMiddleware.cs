using Microsoft.AspNetCore.Identity;

namespace WebApp.Middlewares;

public class RoleMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, RoleManager<IdentityRole> roleManager)
    {
        string[] roles = ["Admin", "User"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new(role));
        }

        await _next(context);
    }


}