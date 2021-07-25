using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetTop10Products()
        {
            throw new System.NotImplementedException();
        }

        public Product UpdateProductDescription(int productId, string description)
        {
            throw new System.NotImplementedException();
        }

        public Product UpdateProductName(int productId, string name)
        {
            throw new System.NotImplementedException();
        }

        public Product UpdateProductStatus(int productId, ProductStatus status)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> CreateEntity(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetEntityById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Product>> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateEntity(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> DeleteEntity(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
