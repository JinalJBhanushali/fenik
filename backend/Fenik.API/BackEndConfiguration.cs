using Application;
using Infrastructure;
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
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return services;
        }
    }
}
