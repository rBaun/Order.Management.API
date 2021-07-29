using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.ProductUseCases.PATCH
{
    public class UpdateProductDescriptionUseCase : IUpdateProductDescriptionUseCase
    {
        private readonly IProductLogic _productLogic;
        private readonly IProductRepository _productRepository;

        public UpdateProductDescriptionUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public async Task<Response<string>> Execute(string productId, string description)
        {
            var response = new Response<string>(
                await _productRepository.UpdateProductDescription(productId, description));

            return response;
        }
    }
}