using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.UseCases.Customers.GET
{
    public interface IGetFirstTimeCustomersUseCase
    {
        Task<PagedResponse<List<Customer>>> Execute(PaginationFilter paginationFilter, string route);
    }
}
