using LoggerService.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Helpers.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static void AddAllRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
        }
    }
}
