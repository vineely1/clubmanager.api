using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ClubManager.Domain.Entities;
using ClubManager.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace ClubManager.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ClubManagerDb");
        services.AddDbContext<ClubManagerDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ClubManagerDbContext>();

        services.AddAuthentication().AddBearerToken(options =>
        {
            options.BearerTokenExpiration = TimeSpan.FromSeconds(1);
        });
    }
}
