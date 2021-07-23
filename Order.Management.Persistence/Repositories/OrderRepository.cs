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
            throw new System.NotImplementedException();
        }

        public List<Order> GetPlacedOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetProcessingOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetShippedOrders()
        {
            throw new System.NotImplementedException();
        }

        public Order UpdateOrderCustomerDetails(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Order UpdateOrderOrderLines(List<OrderLine> orderLines)
        {
            throw new System.NotImplementedException();
        }

        public Order UpdateOrderStatus(OrderStatus status)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> CreateEntity(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetEntityById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Order>> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateEntity(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> DeleteEntity(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
