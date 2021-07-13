using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Persistence.Wrappers.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbAccess _dbAccess;

        public ProductRepository(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public Product CreateEntity(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Product GetEntityById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Product UpdateEntity(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Product DeleteEntity(int id)
        {
            throw new System.NotImplementedException();
        }

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
    }
}
