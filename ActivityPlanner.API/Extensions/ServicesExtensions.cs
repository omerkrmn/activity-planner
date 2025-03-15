using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.EFcore;
using ActivityPlanner.Services.Contracts;
using ActivityPlanner.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ActivityPlanner.Entities.Models;

namespace ActivityPlanner.API.Extensions
{
    public static class ServicesExtensions
    {
        // for db connection
        public static void ConfigureSqlContext(this IServiceCollection services,
                    IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
       services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
           services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;

                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

    }
}
