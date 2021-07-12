using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Persistence.Repositories;
using OrderManagement.Persistence.Wrappers;
using OrderManagement.Persistence.Wrappers.Interfaces;
using Microsoft.Extensions.Configuration;


namespace OrderManagement.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public static void AddPersistenceWrappers(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDbAccess>(sp => new DbAccess(config.GetConnectionString("Default")));
        }
    }
}
