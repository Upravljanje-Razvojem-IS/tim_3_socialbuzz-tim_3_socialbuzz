using Microsoft.Extensions.DependencyInjection;

namespace AddressService.Helpers.DependencyInjection
{
    public static class SwaggerDependencyInjection
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("AddressServiceOpeApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Address service API",
                        Description = "Api for creating and managing cities in application, also for viewing countries",
                        Version = "1",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Name = "Aleksandar Gajić",
                            Email = "aleksandar.gajic8070@gmail.com"
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "Fakultet Tehničkih Nauka, Novi Sad"
                        }
                    }
                );
            });
        }
    }
}
