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
        private readonly IProductRepository _productRepository;
        private readonly IProductLogic _productLogic;

        public UpdateProductStatusUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public Task<Response<ProductStatus>> Execute(string productId, ProductStatus productStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}
