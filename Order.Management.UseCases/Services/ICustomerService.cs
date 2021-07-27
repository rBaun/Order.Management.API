using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.Services
{
    public interface ICustomerService
    {
        Task<Response<Customer>> CreateCustomer(Customer customer);
        Task<PagedResponse<List<Customer>>> GetAllCustomers(PaginationFilter paginationFilter, string route);
        Task<Response<Customer>> GetCustomerById(string customerId);
        Task<PagedResponse<List<Customer>>> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route);
        Task<PagedResponse<List<Customer>>> GetLoyalCustomers(PaginationFilter paginationFilter, string route);
        Task<PagedResponse<List<Customer>>> GetNoAccountCustomers(PaginationFilter paginationFilter, string route);
        Task<Response<string>> UpdateCustomerAddressOn(string customerId, string address);
        Task<Response<string>> UpdateCustomerMailOn(string customerId, string mail);
        Task<Response<string>> UpdateCustomerNameOn(string customerId, string name);
        Task<Response<CustomerStatus>> UpdateCustomerStatusOn(string customerId, CustomerStatus status);
        Task<Response<Customer>> UpdateCustomer(Customer customer);
        Task<Response<int>> DeactivateCustomerOn(string customerId);
        Task<Response<int>> DeleteCustomer(string customerId);
    }
}
