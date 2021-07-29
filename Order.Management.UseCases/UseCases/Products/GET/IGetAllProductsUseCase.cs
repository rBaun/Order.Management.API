using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.UseCases.Products.GET
{
    public interface IGetAllProductsUseCase
    {
        Task<PagedResponse<List<Product>>> Execute(PaginationFilter paginationFilter, string route);
    }
}