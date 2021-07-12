using System.Collections.Generic;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        List<Product> GetTop10Products();
        Product UpdateProductDescription(string description);
        Product UpdateProductName(string name);
        Product UpdateProductStatus(string status);
    }
}
