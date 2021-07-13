using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Persistence.Wrappers.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbAccess _dbAccess;

        public OrderRepository(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public Order CreateEntity(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Order GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Order UpdateEntity(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Order DeleteEntity(int id)
        {
            throw new System.NotImplementedException();
        }

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
    }
}
