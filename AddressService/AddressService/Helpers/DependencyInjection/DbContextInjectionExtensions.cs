using AddressService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressService.Helpers.DependencyInjection
{
    public static class DbContextInjectionExtensions
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddressServiceDatabase>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AddressServiceDatabase"));
            });
        }
    }
}
