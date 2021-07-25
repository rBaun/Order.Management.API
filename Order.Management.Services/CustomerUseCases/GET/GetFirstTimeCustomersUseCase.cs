using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.EntityExtensions;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.GET
{
    public class GetFirstTimeCustomersUseCase : IGetFirstTimeCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUriGenerator _uriGenerator;

        public GetFirstTimeCustomersUseCase(ICustomerRepository customerRepository, IUriGenerator uriGenerator)
        {
            _customerRepository = customerRepository;
            _uriGenerator = uriGenerator;
        }

        public async Task<PagedResponse<List<Customer>>> Execute(PaginationFilter paginationFilter, string route)
        {
            var firstTimeCustomers = await _customerRepository.GetFirstTimeCustomers();
            var validatedFilter = PaginationHelper.ValidatePaginationFilter(paginationFilter);

            return firstTimeCustomers.CreateCustomerPagedResponse(validatedFilter, _uriGenerator, route);
        }
    }
}
