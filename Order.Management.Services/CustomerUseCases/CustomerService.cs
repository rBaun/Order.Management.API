using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Services.CustomerUseCases
{
    public class CustomerService : ICustomerService
    {
        private readonly ICreateCustomerUseCase _createCreateCustomer;
        private readonly IGetAllCustomersUseCase _getAllCustomers;

        public CustomerService(ICreateCustomerUseCase createCustomer, IGetAllCustomersUseCase allCustomers)
        {
            _createCreateCustomer = createCustomer;
            _getAllCustomers = allCustomers;
        }

        public async Task<Response<Customer>> CreateCustomer(Customer customer) 
            => await _createCreateCustomer.Execute(customer);

        public async Task<PagedResponse<List<Customer>>> GetAllCustomers(PaginationFilter paginationFilter, string route)
            => await _getAllCustomers.Execute(paginationFilter, route);

        public Task<Response<Customer>> GetCustomerById(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Customer>>> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Customer>>> GetLoyalCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Customer>>> GetNoAccountCustomers(PaginationFilter paginationFilter, string route)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Customer>> UpdateCustomerAddressOn(int customerId, string address)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Customer>> UpdateCustomerMailOn(int customerId, string mail)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Customer>> UpdateCustomerNameOn(int customerId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Customer>> UpdateCustomerStatusOn(int customerId, CustomerStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Customer>> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeactivateCustomerOn(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
