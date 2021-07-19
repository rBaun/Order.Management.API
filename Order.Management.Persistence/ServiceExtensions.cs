using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Persistence.Repositories;

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
    }
}
