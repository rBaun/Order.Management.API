using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Products.DELETE;
using OrderManagement.Application.UseCases.Products.GET;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Application.UseCases.Products.POST;
using OrderManagement.Application.UseCases.Products.PUT;
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
        private readonly IGetAllProductsUseCase _getProducts;
        private readonly IGetProductByIdUseCase _getProductById;
        private readonly IGetTop10ProductsUseCase _getTop10Products;
        private readonly IUpdateProductDescriptionUseCase _updateProductDescription;
        private readonly IUpdateProductNameUseCase _updateProductName;
        private readonly IUpdateProductStatusUseCase _updateProductStatus;
        private readonly IUpdateProductUseCase _updateProduct;
        private readonly IDeleteProductUseCase _deleteProduct;

        public ProductService(ICreateProductUseCase product, IGetAllProductsUseCase products,
            IGetProductByIdUseCase productById, IGetTop10ProductsUseCase top10Products,
            IUpdateProductDescriptionUseCase updateProductDescription, IUpdateProductNameUseCase updateProductName,
            IUpdateProductStatusUseCase updateProductStatus, IUpdateProductUseCase updateProduct,
            IDeleteProductUseCase deleteProduct)
        {
            _createProduct = product;
            _getProducts = products;
            _getProductById = productById;
            _getTop10Products = top10Products;
            _updateProductDescription = updateProductDescription;
            _updateProductName = updateProductName;
            _updateProductStatus = updateProductStatus;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
        }
        #endregion

        public async Task<Response<Product>> CreateProduct(Product product)
            => await _createProduct.Execute(product);

        public async Task<PagedResponse<List<Product>>> GetAllProducts(PaginationFilter paginationFilter, string route)
            => await _getProducts.Execute(paginationFilter, route);

        public async Task<Response<Product>> GetProductById(string productId)
            => await _getProductById.Execute(productId);

        public async Task<Response<List<Product>>> GetTop10Products()
            => await _getTop10Products.Execute();

        public async Task<Response<Product>> UpdateProduct(Product product)
            => await _updateProduct.Execute(product);

        public async Task<Response<string>> UpdateProductDescription(string productId, string description)
            => await _updateProductDescription.Execute(productId, description);

        public async Task<Response<string>> UpdateProductName(string productId, string name)
            => await _updateProductName.Execute(productId, name);

        public async Task<Response<ProductStatus>> UpdateProductStatusOn(string productId, ProductStatus productStatus)
            => await _updateProductStatus.Execute(productId, productStatus);

        public async Task<Response<Product>> DeleteProduct(string productId)
            => await _deleteProduct.Execute(productId);
    }
}
