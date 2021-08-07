using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.Collections;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderRepository()
        {
            _ordersCollection = OrdersCollection.Open();
        }

        public async Task<Order> CreateEntity(Order entity)
        {
            await _ordersCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<Order> GetEntityById(string id)
        {
            var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(id));
            var order = await _ordersCollection.Find(filter).FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<Order>> GetEntities()
        {
            var filter = Builders<Order>.Filter.Empty;
            var orders = await _ordersCollection.Find(filter).ToListAsync();

            return orders;
        }

        public async Task<Order> UpdateEntity(Order entity)
        {
            var options = new FindOneAndReplaceOptions<Order> {ReturnDocument = ReturnDocument.After};
            var updatedOrder =
                await _ordersCollection.FindOneAndReplaceAsync<Order>(
                    order => order.OrderId == entity.OrderId, entity, options);

            return updatedOrder;
        }

        public async Task<Order> DeleteEntity(string id)
        {
            var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(id));
            var deletedOrder = await _ordersCollection.FindOneAndDeleteAsync(filter);

            return deletedOrder;
        }

        public async Task<List<Order>> GetCustomerOrders(string mail)
        {
            var filter = Builders<Order>.Filter.Eq("customer.mail", mail);
            var customerOrders = await _ordersCollection.Find(filter).ToListAsync();

            return customerOrders;
        }

        public async Task<List<Order>> GetPlacedOrders()
        {
            var filter = Builders<Order>.Filter.Eq("orderStatus", OrderStatus.Received);
            var placedOrders = await _ordersCollection.Find(filter).ToListAsync();

            return placedOrders;
        }

        public async Task<List<Order>> GetProcessingOrders()
        {
            var filter = Builders<Order>.Filter.Eq("orderStatus", OrderStatus.Processing);
            var ordersInProgress = await _ordersCollection.Find(filter).ToListAsync();

            return ordersInProgress;
        }

        public async Task<List<Order>> GetShippedOrders()
        {
            var filter = Builders<Order>.Filter.Eq("orderStatus", OrderStatus.Shipped);
            var shippedOrders = await _ordersCollection.Find(filter).ToListAsync();

            return shippedOrders;
        }

        public Task<Order> UpdateOrderCustomerDetails(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderOrderLines(List<OrderLine> orderLines)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderStatus(OrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}