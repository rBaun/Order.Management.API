using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases
{
    public class CustomerService : ICustomerService
    {
        private readonly ICreateCustomerUseCase _createCustomer;

        public CustomerService(ICreateCustomerUseCase customer)
        {
            _createCustomer = customer;
        }

        public async Task<Customer> CreateCustomer(Customer customer) 
            => await _createCustomer.Execute(customer);

        public Task<List<Customer>> GetAllCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetLoyalCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetNoAccountCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAddressOn(int customerId, string address)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerMailOn(int customerId, string mail)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerNameOn(int customerId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerStatusOn(int customerId, CustomerStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeactivateCustomerOn(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
