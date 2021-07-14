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
        Customer CreateCustomer(Customer customer);
        List<Customer> GetAllCustomers(PaginationFilter paginationFilter, string route);
        Customer GetCustomerById(int customerId);
        List<Customer> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route);
        List<Customer> GetLoyalCustomers(PaginationFilter paginationFilter, string route);
        List<Customer> GetNoAccountCustomers(PaginationFilter paginationFilter, string route);
        Customer UpdateCustomerAddressOn(int customerId, string address);
        Customer UpdateCustomerMailOn(int customerId, string mail);
        Customer UpdateCustomerNameOn(int customerId, string name);
        Customer UpdateCustomerStatusOn(int customerId, CustomerStatus status);
        Customer UpdateCustomer(Customer customer);
        int DeactivateCustomerOn(int customerId);
        int DeleteCustomer(int customerId);
    }
}
