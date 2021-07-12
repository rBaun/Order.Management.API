using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Customers.DELETE;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Application.UseCases.Customers.PUT;
using OrderManagement.Application.UseCases.Orders.DELETE;
using OrderManagement.Application.UseCases.Orders.GET;
using OrderManagement.Application.UseCases.Orders.PATCH;
using OrderManagement.Application.UseCases.Orders.POST;
using OrderManagement.Application.UseCases.Orders.PUT;
using OrderManagement.Application.UseCases.Products.DELETE;
using OrderManagement.Application.UseCases.Products.GET;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Application.UseCases.Products.POST;
using OrderManagement.Application.UseCases.Products.PUT;
using OrderManagement.Services.BusinessLogic;
using OrderManagement.Services.BusinessLogic.Interfaces;
using OrderManagement.Services.CustomerUseCases;
using OrderManagement.Services.CustomerUseCases.DELETE;
using OrderManagement.Services.CustomerUseCases.GET;
using OrderManagement.Services.CustomerUseCases.PATCH;
using OrderManagement.Services.CustomerUseCases.POST;
using OrderManagement.Services.CustomerUseCases.PUT;
using OrderManagement.Services.OrderUseCases;
using OrderManagement.Services.OrderUseCases.DELETE;
using OrderManagement.Services.OrderUseCases.GET;
using OrderManagement.Services.OrderUseCases.PATCH;
using OrderManagement.Services.OrderUseCases.POST;
using OrderManagement.Services.OrderUseCases.PUT;
using OrderManagement.Services.ProductUseCases;
using OrderManagement.Services.ProductUseCases.DELETE;
using OrderManagement.Services.ProductUseCases.GET;
using OrderManagement.Services.ProductUseCases.PATCH;
using OrderManagement.Services.ProductUseCases.POST;
using OrderManagement.Services.ProductUseCases.PUT;

namespace OrderManagement.Services
{
    public static class ServiceExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IProductLogic, ProductLogic>();
        }

        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
        }

        public static void AddCustomerUseCases(this IServiceCollection services)
        {
            // DELETE
            services.AddTransient<IDeleteCustomerUseCase, DeleteCustomerUseCase>();

            // GET
            services.AddTransient<IGetAllCustomersUseCase, GetAllCustomersUseCase>();
            services.AddTransient<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
            services.AddTransient<IGetFirstTimeCustomersUseCase, GetFirstTimeCustomersUseCase>();
            services.AddTransient<IGetLoyalCustomersUseCase, GetLoyalCustomersUseCase>();
            services.AddTransient<IGetNoAccountCustomersUseCase, GetNoAccountCustomersUseCase>();

            // PATCH
            services.AddTransient<IDeactivateCustomerAccountUseCase, DeactivateCustomerAccountUseCase>();
            services.AddTransient<IUpdateCustomerAddressUseCase, UpdateCustomerAddressUseCase>();
            services.AddTransient<IUpdateCustomerMailUseCase, UpdateCustomerMailUseCase>();
            services.AddTransient<IUpdateCustomerNameUseCase, UpdateCustomerNameUseCase>();
            services.AddTransient<IUpdateCustomerStatusUseCase, UpdateCustomerStatusUseCase>();

            // POST
            services.AddTransient<ICreateCustomerUseCase, CreateCustomerUseCase>();

            // PUT
            services.AddTransient<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
        }

        public static void AddOrderUseCases(this IServiceCollection services)
        {
            // DELETE
            services.AddTransient<IDeleteOrderUseCase, DeleteOrderUseCase>();

            // GET
            services.AddTransient<IGetAllOrdersUseCase, GetAllOrdersUseCase>();
            services.AddTransient<IGetOrderByIdUseCase, GetOrderByIdUseCase>();
            services.AddTransient<IGetOrdersOnCustomerByMailUseCase, GetOrdersOnCustomerByMailUseCase>();
            services.AddTransient<IGetOrdersPlacedUseCase, GetOrdersPlacedUseCase>();
            services.AddTransient<IGetOrdersProcessingUseCase, GetOrdersProcessingUseCase>();
            services.AddTransient<IGetOrdersShippedUseCase, GetOrdersShippedUseCase>();

            // PATCH
            services.AddTransient<IUpdateOrderCustomerDetailsUseCase, UpdateOrderCustomerDetailsUseCase>();
            services.AddTransient<IUpdateOrderOrderLinesUseCase, UpdateOrderOrderLinesUseCase>();
            services.AddTransient<IUpdateOrderStatusUseCase, UpdateOrderStatusUseCase>();

            // POST 
            services.AddTransient<ICreateOrderUseCase, CreateOrderUseCase>();
            
            // PUT
            services.AddTransient<IUpdateOrderUseCase, UpdateOrderUseCase>();
        }

        public static void AddProductUseCases(this IServiceCollection services)
        {
            // DELETE
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();

            // GET
            services.AddTransient<IGetAllProductsUseCase, GetAllProductsUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IGetTop10ProductsUseCase, GetTop10ProductsUseCase>();

            // PATCH
            services.AddTransient<IUpdateProductDescriptionUseCase, UpdateProductDescriptionUseCase>();
            services.AddTransient<UpdateProductNameUseCase, UpdateProductNameUseCase>();
            services.AddTransient<IUpdateProductStatusUseCase, UpdateProductStatusUseCase>();

            // POST
            services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();

            // PUT
            services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
        }
    }
}
