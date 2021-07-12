using System.Collections.Generic;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        List<Order> GetCustomerOrders(string mail);
        List<Order> GetPlacedOrders();
        List<Order> GetProcessingOrders();
        List<Order> GetShippedOrders();
        Order UpdateOrderCustomerDetails(Customer customer);
        Order UpdateOrderOrderLines(List<OrderLine> orderLines);
        Order UpdateOrderStatus(string status);
    }
}
