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
    /**
     * This is a filler class utilized to make the controller easier to read and maintain.
     * The sole purpose of this class is to avoid dependency injecting all the use cases in the customer controller
     */
    public class CustomerService : ICustomerService
    {
        #region Dependency Injection
        private readonly ICreateCustomerUseCase _createCreateCustomer;
        private readonly IGetAllCustomersUseCase _getAllCustomers;
        private readonly IGetCustomerByIdUseCase _getCustomerById;
        private readonly IGetFirstTimeCustomersUseCase _getFirstTimeCustomers;
        private readonly IGetLoyalCustomersUseCase _getLoyalCustomers;
        private readonly IGetNoAccountCustomersUseCase _getNoAccountCustomers;

        public CustomerService(ICreateCustomerUseCase createCustomer, IGetAllCustomersUseCase allCustomers, IGetCustomerByIdUseCase customerById, IGetFirstTimeCustomersUseCase firstTimeCustomers, IGetLoyalCustomersUseCase loyalCustomers, IGetNoAccountCustomersUseCase noAccountCustomers)
        {
            _createCreateCustomer = createCustomer;
            _getAllCustomers = allCustomers;
            _getCustomerById = customerById;
            _getFirstTimeCustomers = firstTimeCustomers;
            _getLoyalCustomers = loyalCustomers;
            _getNoAccountCustomers = noAccountCustomers;
        }
        #endregion

        #region Use Cases
        public async Task<Response<Customer>> CreateCustomer(Customer customer) 
            => await _createCreateCustomer.Execute(customer);

        public async Task<PagedResponse<List<Customer>>> GetAllCustomers(PaginationFilter paginationFilter, string route)
            => await _getAllCustomers.Execute(paginationFilter, route);

        public async Task<Response<Customer>> GetCustomerById(string customerId)
            => await _getCustomerById.Execute(customerId);

        public async Task<PagedResponse<List<Customer>>> GetFirstTimeCustomers(PaginationFilter paginationFilter, string route)
            => await _getFirstTimeCustomers.Execute(paginationFilter, route);

        public async Task<PagedResponse<List<Customer>>> GetLoyalCustomers(PaginationFilter paginationFilter, string route)
            => await _getLoyalCustomers.Execute(paginationFilter, route);

        public async Task<PagedResponse<List<Customer>>> GetNoAccountCustomers(PaginationFilter paginationFilter, string route)
            => await _getNoAccountCustomers.Execute(paginationFilter, route);

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
        #endregion
    }
}
