using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public async Task<Customer> GetEntityById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(id));
            var customer = await _customerCollection.Find(filter).FirstOrDefaultAsync();

            return customer;
        }

        public async Task<List<Customer>> GetEntities()
        {
            var filter = Builders<Customer>.Filter.Empty;
            var customers = await _customerCollection.Find(filter).ToListAsync();

            return customers;
        }

        public async Task<Customer> UpdateEntity(Customer entity)
        {
            var options = new FindOneAndReplaceOptions<Customer>
            {
                ReturnDocument = ReturnDocument.After
            };
            var updatedCustomer =
                await _customerCollection.FindOneAndReplaceAsync<Customer>(
                    customer => customer.CustomerId == entity.CustomerId, entity, options);

            return updatedCustomer;
        }

        public async Task<Customer> DeleteEntity(string id)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(id));
            var deletedCustomer = await _customerCollection.FindOneAndDeleteAsync(filter);

            return deletedCustomer;
        }

        public async Task<List<Customer>> GetFirstTimeCustomers()
        {
            var filter = Builders<Customer>.Filter.Eq("customerStatus", CustomerStatus.PurchasedOnce);
            var firstTimeCustomers = await _customerCollection.Find(filter).ToListAsync();

            return firstTimeCustomers;
        }

        public async Task<List<Customer>> GetLoyalCustomers()
        {
            var filter = Builders<Customer>.Filter.Eq("customerStatus", CustomerStatus.PurchasedMultiple);
            var loyalCustomers = await _customerCollection.Find(filter).ToListAsync();

            return loyalCustomers;
        }

        public async Task<List<Customer>> GetNoAccountCustomers()
        {
            var filter = Builders<Customer>.Filter.Eq("customerStatus", CustomerStatus.NoAccount);
            var noAccountCustomers = await _customerCollection.Find(filter).ToListAsync();

            return noAccountCustomers;
        }

        public async Task<string> UpdateCustomerAddress(string customerId, string address)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(customerId));
            var update = Builders<Customer>.Update.Set("address", address);
            var options = new FindOneAndUpdateOptions<Customer> {ReturnDocument = ReturnDocument.After};

            var updatedCustomer = await _customerCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedCustomer.Address;
        }

        public async Task<string> UpdateCustomerMail(string customerId, string mail)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(customerId));
            var update = Builders<Customer>.Update.Set("mail", mail);
            var options = new FindOneAndUpdateOptions<Customer> {ReturnDocument = ReturnDocument.After};

            var updatedCustomer = await _customerCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedCustomer.Mail;
        }

        public async Task<string> UpdateCustomerFirstName(string customerId, string firstName)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(customerId));
            var update = Builders<Customer>.Update.Set("firstName", firstName);
            var options = new FindOneAndUpdateOptions<Customer> {ReturnDocument = ReturnDocument.After};

            var updatedCustomer = await _customerCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedCustomer.FirstName;
        }

        public async Task<string> UpdateCustomerLastName(string customerId, string lastName)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(customerId));
            var update = Builders<Customer>.Update.Set("lastName", lastName);
            var options = new FindOneAndUpdateOptions<Customer> {ReturnDocument = ReturnDocument.After};

            var updatedCustomer = await _customerCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedCustomer.LastName;
        }

        public async Task<CustomerStatus> UpdateCustomerStatus(string customerId, CustomerStatus status)
        {
            var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(customerId));
            var update = Builders<Customer>.Update.Set("customerStatus", status);
            var options = new FindOneAndUpdateOptions<Customer> {ReturnDocument = ReturnDocument.After};

            var updatedCustomer = await _customerCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedCustomer.CustomerStatus;
        }
    }
}