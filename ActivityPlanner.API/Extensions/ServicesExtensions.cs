using ActivityPlanner.Repositories.EFcore;
using Microsoft.EntityFrameworkCore;

namespace ActivityPlanner.API.Extensions
{
    public static class ServicesExtensions
    {
        // for db connection
        public static void ConfigureSqlContext(this IServiceCollection services,
                    IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    } 
}
