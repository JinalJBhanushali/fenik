using Application.Common.Behaviors;
using Application.Features.CustomerManager.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //autoMapper
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            // FluentValidation 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            // Register services 
            services.Scan(scan => scan
                .FromAssemblyOf<CreateCustomerHandler>()
                .AddClasses(classes => classes.InNamespaces("Application.Features"))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
