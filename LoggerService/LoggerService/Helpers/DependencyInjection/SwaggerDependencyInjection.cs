using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Helpers.DependencyInjection
{
    public static class SwaggerDependencyInjection
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("LoggerServiceOpeApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Logger service API",
                        Description = "Api for creating and managing logs of events that happen in application",
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
