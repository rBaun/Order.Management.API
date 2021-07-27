using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Products.POST;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Services.ProductUseCases
{
    public class ProductService : IProductService
    {
        #region Dependency Injection
        private readonly ICreateProductUseCase _createProduct;

        public ProductService(ICreateProductUseCase product)
        {
            _createProduct = product;
        }
        #endregion

        public async Task<Response<Product>> CreateProduct(Product product)
            => await _createProduct.Execute(product);

        public Task<PagedResponse<List<Product>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product>> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Product>>> GetTop10Products()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product>> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateProductDescription(int productId, string description)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateProductName(int productId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProductStatus>> UpdateProductStatusOn(int productId, ProductStatus productStatus)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
