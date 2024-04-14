using Infrastructure.Services;

namespace WebApp.Configurations;

public static class ServicesConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AccountService>();
    }
}