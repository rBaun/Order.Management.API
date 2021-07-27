using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Collections;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository()
        {
            _productCollection = ProductsCollection.Open();
        }

        public async Task<Product> CreateEntity(Product entity)
        {
            await _productCollection.InsertOneAsync(entity);

            return entity;
        }

        public Task<Product> GetEntityById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Product>> GetEntities()
        {
            var filter = Builders<Product>.Filter.Empty;
            var products = await _productCollection.Find(filter).ToListAsync();

            return products;
        }

        public Task<Product> UpdateEntity(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> DeleteEntity(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Product>> GetTop10Products()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProductDescription(int productId, string description)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProductName(int productId, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProductStatus(int productId, ProductStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}
