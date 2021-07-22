using System;
using System.Collections.Generic;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.OrderUseCases
{
    public class OrderService : IOrderService
    {
        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersOn(string customerMail)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetPlacedOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetProcessingOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetShippedOrders()
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderCustomerOn(int orderId, Customer customer)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderLinesOn(int orderId, List<OrderLine> orderLines)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderStatusOn(int orderId, OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
