using Infrastructure.DataAccessManager.EFCore;
using Infrastructure.EmailManager;
using Infrastructure.LogManager.Serilogs;
using Infrastructure.SecurityManager.AspNetIdentity;
using Infrastructure.SecurityManager.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //>>> DataAccess
            services.RegisterDataAccess(configuration);
            //>>> Serilog
            services.RegisterSerilog(configuration);

            //>>> Token Manager
            services.RegisterToken(configuration);
            //>>> Security Manager
            services.RegisterSecurityManager(configuration);

            //>>> DeletedById Manager
            services.RegisterEmailManager(configuration);
            return services;
        }
    }
}
