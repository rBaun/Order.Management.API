using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers(PaginationFilter paginationFilter, string route);
        Task<Customer> GetCustomerById(int customerId);
        Task<List<Customer>> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route);
        Task<List<Customer>> GetLoyalCustomers(PaginationFilter paginationFilter, string route);
        Task<List<Customer>> GetNoAccountCustomers(PaginationFilter paginationFilter, string route);
        Task<Customer> UpdateCustomerAddressOn(int customerId, string address);
        Task<Customer> UpdateCustomerMailOn(int customerId, string mail);
        Task<Customer> UpdateCustomerNameOn(int customerId, string name);
        Task<Customer> UpdateCustomerStatusOn(int customerId, CustomerStatus status);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<int> DeactivateCustomerOn(int customerId);
        Task<int> DeleteCustomer(int customerId);
    }
}
