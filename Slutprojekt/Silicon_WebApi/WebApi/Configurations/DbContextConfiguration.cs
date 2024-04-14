using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
    }
}