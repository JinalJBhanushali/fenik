using Infrastructure.DataAccessManager.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.CQS.Commands;
using Application.Common.CQS.Queries;
using Application.Common.Repository;
using Serilog;
using Microsoft.Extensions.Logging;
using Infrastructure.DataAccessManager.EFCore.Repositories;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.DataAccessManager.EFCore
{
    public static class DI
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                  options.UseSqlServer(connectionString)
                  .LogTo(Log.Information, LogLevel.Information)
                  .EnableSensitiveDataLogging()
              );
            services.AddDbContext<CommandContext>(options =>
                options.UseSqlServer(connectionString)
                .LogTo(Log.Information, LogLevel.Information)
                .EnableSensitiveDataLogging()
            );
            services.AddDbContext<QueryContext>(options =>
                options.UseSqlServer(connectionString)
                .LogTo(Log.Information, LogLevel.Information)
                .EnableSensitiveDataLogging()
            );
            services.AddScoped<ICommandContext, CommandContext>();
            services.AddScoped<IQueryContext, QueryContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
       
            return services;
        }
        //Extension Method of IHost to create database on application startup
        public static IHost CreateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            // Create database using DataContext
            var dataContext = serviceProvider.GetRequiredService<DataContext>();
            //dataContext.Database.EnsureCreated(); // Ensure database is created (development only)
            dataContext.Database.Migrate();
            return host;
        }
    }
}
