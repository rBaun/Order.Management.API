using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<Product>> GetTop10Products();
        Task<string> UpdateProductDescription(string productId, string description);
        Task<string> UpdateProductName(string productId, string name);
        Task<ProductStatus> UpdateProductStatus(string productId, ProductStatus status);
    }
}