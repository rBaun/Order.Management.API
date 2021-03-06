using System;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.ProductUseCases.PATCH
{
    public class UpdateProductStatusUseCase : IUpdateProductStatusUseCase
    {
        private readonly IProductLogic _productLogic;
        private readonly IProductRepository _productRepository;

        public UpdateProductStatusUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public async Task<Response<ProductStatus>> Execute(string productId, ProductStatus productStatus)
        {
            var response = new Response<ProductStatus>(productStatus)
            {
                Data = await _productRepository.UpdateProductStatus(productId, productStatus)
            };

            return response;
        }
    }
}