using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.EntityExtensions;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.GET
{
    public class GetAllCustomersUseCase : IGetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUriGenerator _uriGenerator;

        public GetAllCustomersUseCase(ICustomerRepository customerRepository, IUriGenerator uriGenerator)
        {
            _customerRepository = customerRepository;
            _uriGenerator = uriGenerator;
        }

        public async Task<PagedResponse<List<Customer>>> Execute(PaginationFilter paginationFilter, string route)
        {
            var customers = await _customerRepository.GetEntities();
            var validatedFilter = PaginationHelper.ValidatePaginationFilter(paginationFilter);

            return PaginationHelper.CreatePagedResponse(customers
                .Search(validatedFilter.SearchTerm)
                .Sort(validatedFilter.OrderBy)
                .Skip((validatedFilter.PageNumber - 1) * validatedFilter.PageSize)
                .Take(validatedFilter.PageSize)
                .ToList(), validatedFilter, customers.Search(validatedFilter.SearchTerm).Count, _uriGenerator, route);
        }
    }
}
