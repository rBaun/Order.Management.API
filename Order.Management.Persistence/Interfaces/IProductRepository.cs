using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        List<Product> GetTop10Products();
        Product UpdateProductDescription(int productId, string description);
        Product UpdateProductName(int productId, string name);
        Product UpdateProductStatus(int productId, ProductStatus status);
    }
}
