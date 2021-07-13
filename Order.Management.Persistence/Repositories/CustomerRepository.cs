using System.Collections.Generic;
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

        public Customer CreateEntity(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateEntity(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Customer DeleteEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetFirstTimeCustomers()
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetLoyalCustomers()
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetNoAccountCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomerAddress(string address)
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomerMail(string mail)
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomerName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomerStatus(CustomerStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}
