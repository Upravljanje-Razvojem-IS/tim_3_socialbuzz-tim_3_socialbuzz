using LoggerService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Helpers.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static void AddAllServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
