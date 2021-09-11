using AddressService.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AddressService.Helpers.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
        }
    }
}
