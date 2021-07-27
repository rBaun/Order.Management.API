using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<Product>> GetTop10Products();
        Task<Product> UpdateProductDescription(int productId, string description);
        Task<Product> UpdateProductName(int productId, string name);
        Task<Product> UpdateProductStatus(int productId, ProductStatus status);
    }
}
