using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        List<Order> GetCustomerOrdersOn(string customerMail);
        List<Order> GetPlacedOrders();
        List<Order> GetProcessingOrders();
        List<Order> GetShippedOrders();
        Order UpdateOrderCustomerOn(int orderId, Customer customer);
        Order UpdateOrderLinesOn(int orderId, List<OrderLine> orderLines);
        Order UpdateOrderStatusOn(int orderId, OrderStatus orderStatus);
        Order UpdateOrder(Order order);
        int DeleteOrder(int orderId);
    }
}