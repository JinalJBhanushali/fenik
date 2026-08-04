using Application;
using Infrastructure;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace Fenik.API
{
    public static class BackEndConfiguration
    {
        public static IServiceCollection AddBackEndServices(this IServiceCollection services, IConfiguration configuration)
        {
            //>>> Application Layer
            services.AddApplicationServices();

            //>>> Infrastructure Layer 
            services.AddInfrastructureServices(configuration);
            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
