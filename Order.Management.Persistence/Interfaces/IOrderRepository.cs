using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        Task<List<Order>> GetCustomerOrders(string mail);
        Task<List<Order>> GetPlacedOrders();
        Task<List<Order>> GetProcessingOrders();
        Task<List<Order>> GetShippedOrders();
        Task<Order> UpdateOrderCustomerDetails(Customer customer);
        Task<Order> UpdateOrderOrderLines(List<OrderLine> orderLines);
        Task<Order> UpdateOrderStatus(OrderStatus status);
    }
}