using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetCustomerOrders(string mail)
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

        public Order UpdateOrderCustomerDetails(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderOrderLines(List<OrderLine> orderLines)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderStatus(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Order> CreateEntity(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateEntity(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteEntity(string id)
        {
            throw new NotImplementedException();
        }
    }
}