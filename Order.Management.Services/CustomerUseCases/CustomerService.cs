using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Services.CustomerUseCases
{
    public class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetLoyalCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetNoAccountCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomerAddressOn(int customerId, string address)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomerMailOn(int customerId, string mail)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomerNameOn(int customerId, string name)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomerStatusOn(int customerId, CustomerStatus status)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeactivateCustomerOn(int customerId)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
