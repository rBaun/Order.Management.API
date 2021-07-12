﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OrderManagement.Application.Extensions;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order.Management.API", Version = "v1" });
            });
        }

        public static void AddApiVersions(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify Default API version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // Use default, if client did not specify version
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void AddPersistence(this IServiceCollection services)
        {
            Persistence.ServiceExtensions.AddRepositories(services);
        }

        public static void AddServices(this IServiceCollection services)
        {
            Services.ServiceExtensions.AddBusinessLogic(services);
            Services.ServiceExtensions.AddCustomerServices(services);
            Services.ServiceExtensions.AddOrderServices(services);
            Services.ServiceExtensions.AddProductServices(services);
        }
    }
}
