using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Collections;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository()
        {
            _customerCollection = CustomersCollection.Open();
        }

        public async Task<Customer> CreateEntity(Customer entity)
        {
            await _customerCollection.InsertOneAsync(entity);

            return entity;
        }

        public Task<Customer> GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Customer>> GetEntities()
        {
            var filter = Builders<Customer>.Filter.Empty;
            var customers = await _customerCollection.Find(filter).ToListAsync();

            return customers;
        }

        public Task<Customer> UpdateEntity(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> DeleteEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Customer>> GetFirstTimeCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Customer>> GetLoyalCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Customer>> GetNoAccountCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAddress(string address)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerMail(string mail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerStatus(CustomerStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}
