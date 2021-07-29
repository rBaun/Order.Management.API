using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public async Task<Product> GetEntityById(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
            var product = await _productCollection.Find(filter).FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<Product>> GetEntities()
        {
            var filter = Builders<Product>.Filter.Empty;
            var products = await _productCollection.Find(filter).ToListAsync();

            return products;
        }

        public async Task<Product> UpdateEntity(Product entity)
        {
            var options = new FindOneAndReplaceOptions<Product> {ReturnDocument = ReturnDocument.After};
            var updatedProduct =
                await _productCollection.FindOneAndReplaceAsync<Product>(
                    product => product.ProductId == entity.ProductId, entity, options);

            return updatedProduct;
        }

        public async Task<Product> DeleteEntity(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
            var deletedProduct = await _productCollection.FindOneAndDeleteAsync(filter);

            return deletedProduct;
        }

        public Task<List<Product>> GetTop10Products()
        {
            // TODO: Reconsider making this an extension method instead.
            // Fetch all product records and make the extension method do the logic behind it
            throw new NotImplementedException();
        }

        public async Task<string> UpdateProductDescription(string productId, string description)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(productId));
            var update = Builders<Product>.Update.Set("description", description);
            var options = new FindOneAndUpdateOptions<Product> {ReturnDocument = ReturnDocument.After};

            var updatedProduct = await _productCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedProduct.Description;
        }

        public async Task<string> UpdateProductName(string productId, string name)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(productId));
            var update = Builders<Product>.Update.Set("title", name);
            var options = new FindOneAndUpdateOptions<Product> {ReturnDocument = ReturnDocument.After};

            var updatedProduct = await _productCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedProduct.Title;
        }

        public async Task<ProductStatus> UpdateProductStatus(string productId, ProductStatus status)
        {
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(productId));
            var update = Builders<Product>.Update.Set("productStatus", status);
            var options = new FindOneAndUpdateOptions<Product> {ReturnDocument = ReturnDocument.After};

            var updatedProduct = await _productCollection.FindOneAndUpdateAsync(filter, update, options);

            return updatedProduct.ProductStatus;
        }
    }
}