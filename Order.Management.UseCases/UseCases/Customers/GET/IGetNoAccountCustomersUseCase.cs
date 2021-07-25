using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.UseCases.Customers.GET
{
    public interface IGetNoAccountCustomersUseCase
    {
        Task<PagedResponse<List<Customer>>> Execute(PaginationFilter paginationFilter, string route);
    }
}
