using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Persistence.Wrappers.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbAccess _dbAccess;

        public CustomerRepository(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public Task<Customer> CreateEntity(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Customer>> GetEntities()
        {
            throw new System.NotImplementedException();
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
