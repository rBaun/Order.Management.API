using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.EntityExtensions;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.GET
{
    public class GetNoAccountCustomersUseCase : IGetNoAccountCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUriGenerator _uriGenerator;

        public GetNoAccountCustomersUseCase(ICustomerRepository customerRepository, IUriGenerator uriGenerator)
        {
            _customerRepository = customerRepository;
            _uriGenerator = uriGenerator;
        }

        public async Task<PagedResponse<List<Customer>>> Execute(PaginationFilter paginationFilter, string route)
        {
            var noAccountCustomers = await _customerRepository.GetNoAccountCustomers();
            var validatedFilter = PaginationHelper.ValidatePaginationFilter(paginationFilter);

            return noAccountCustomers.CreateCustomerPagedResponse(validatedFilter, _uriGenerator, route);
        }
    }
}