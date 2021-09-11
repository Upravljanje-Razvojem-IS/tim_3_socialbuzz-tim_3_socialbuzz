using LoggerService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Helpers.DependencyInjection
{
    public static class DbContextInjectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LoggerServiceDatabase>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LoggerServiceDatabase"));
            });
        }
    }
}
