﻿using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Helpers.DependencyInjection
{
    public static class CorsDependencyInjection
    {
        public static void AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAllOrigins",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });
        }
    }
}
