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
        Task<PagedResponse<List<Product>>> GetAllProducts();
        Task<Response<Product>> GetProductById(int productId);
        Task<PagedResponse<List<Product>>> GetTop10Products();
        Task<Response<Product>> UpdateProduct(Product product);
        Task<Response<string>> UpdateProductDescription(int productId, string description);
        Task<Response<string>> UpdateProductName(int productId, string name);
        Task<Response<ProductStatus>> UpdateProductStatusOn(int productId, ProductStatus productStatus);
        Task<Response<int>> DeleteProduct(int productId);
    }
}
