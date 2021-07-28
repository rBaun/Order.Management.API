using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Application.Services
{
    public interface IProductService
    {
        Task<Response<Product>> CreateProduct(Product product);
        Task<PagedResponse<List<Product>>> GetAllProducts(PaginationFilter paginationFilter, string route);
        Task<Response<Product>> GetProductById(string productId);
        Task<Response<List<Product>>> GetTop10Products();
        Task<Response<Product>> UpdateProduct(Product product);
        Task<Response<string>> UpdateProductDescription(string productId, string description);
        Task<Response<string>> UpdateProductName(string productId, string name);
        Task<Response<ProductStatus>> UpdateProductStatusOn(string productId, ProductStatus productStatus);
        Task<Response<int>> DeleteProduct(string productId);
    }
}
