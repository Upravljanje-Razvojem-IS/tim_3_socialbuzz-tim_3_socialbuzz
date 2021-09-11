using AddressService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AddressService.Helpers.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
        }
    }
}
