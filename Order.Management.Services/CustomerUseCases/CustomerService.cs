using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Customers.DELETE;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Application.UseCases.Customers.PUT;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Services.CustomerUseCases
{
    public class CustomerService : ICustomerService
    {
        #region Dependency Injection
        private readonly ICreateCustomerUseCase _createCreateCustomer;
        private readonly IGetAllCustomersUseCase _getAllCustomers;
        private readonly IGetCustomerByIdUseCase _getCustomerById;
        private readonly IGetFirstTimeCustomersUseCase _getFirstTimeCustomers;
        private readonly IGetLoyalCustomersUseCase _getLoyalCustomers;
        private readonly IGetNoAccountCustomersUseCase _getNoAccountCustomers;
        private readonly IUpdateCustomerUseCase _updateCustomer;
        private readonly IUpdateCustomerAddressUseCase _updateCustomerAddress;
        private readonly IUpdateCustomerMailUseCase _updateCustomerMail;
        private readonly IUpdateCustomerFirstNameUseCase _updateCustomerFirstName;
        private readonly IUpdateCustomerLastNameUseCase _updateCustomerLastName;
        private readonly IUpdateCustomerStatusUseCase _updateCustomerStatus;
        private readonly IDeleteCustomerUseCase _deleteCustomer;

        public CustomerService(ICreateCustomerUseCase createCustomer, IGetAllCustomersUseCase allCustomers,
            IGetCustomerByIdUseCase customerById, IGetFirstTimeCustomersUseCase firstTimeCustomers,
            IGetLoyalCustomersUseCase loyalCustomers, IGetNoAccountCustomersUseCase noAccountCustomers,
            IUpdateCustomerUseCase updateCustomer, IUpdateCustomerAddressUseCase updateCustomerAddress,
            IUpdateCustomerMailUseCase updateCustomerMail, IUpdateCustomerFirstNameUseCase updateCustomerFirstName,
            IUpdateCustomerLastNameUseCase updateCustomerLastName, IUpdateCustomerStatusUseCase updateCustomerStatus,
            IDeleteCustomerUseCase deleteCustomer)
        {
            _createCreateCustomer = createCustomer;
            _getAllCustomers = allCustomers;
            _getCustomerById = customerById;
            _getFirstTimeCustomers = firstTimeCustomers;
            _getLoyalCustomers = loyalCustomers;
            _getNoAccountCustomers = noAccountCustomers;
            _updateCustomer = updateCustomer;
            _updateCustomerAddress = updateCustomerAddress;
            _updateCustomerMail = updateCustomerMail;
            _updateCustomerFirstName = updateCustomerFirstName;
            _updateCustomerLastName = updateCustomerLastName;
            _updateCustomerStatus = updateCustomerStatus;
            _deleteCustomer = deleteCustomer;
        }

        #endregion

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

        public async Task<Response<string>> UpdateCustomerAddressOn(string customerId, string address)
            => await _updateCustomerAddress.Execute(customerId, address);

        public async Task<Response<string>> UpdateCustomerMailOn(string customerId, string mail)
            => await _updateCustomerMail.Execute(customerId, mail);

        public async Task<Response<string>> UpdateCustomerFirstNameOn(string customerId, string firstName)
            => await _updateCustomerFirstName.Execute(customerId, firstName);

        public async Task<Response<string>> UpdateCustomerLastNameOn(string customerId, string lastName)
            => await _updateCustomerLastName.Execute(customerId, lastName);

        public async Task<Response<CustomerStatus>> UpdateCustomerStatusOn(string customerId, CustomerStatus status)
            => await _updateCustomerStatus.Execute(customerId, status);

        public async Task<Response<Customer>> UpdateCustomer(Customer customer)
            => await _updateCustomer.Execute(customer);

        public Task<Response<int>> DeactivateCustomerOn(string customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Customer>> DeleteCustomer(string customerId)
            => await _deleteCustomer.Execute(customerId);
    }
}
