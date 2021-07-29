using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.ProductUseCases.PATCH
{
    public class UpdateProductNameUseCase : IUpdateProductNameUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductLogic _productLogic;

        public UpdateProductNameUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public async Task<Response<string>> Execute(string productId, string name)
        {
            var response = new Response<string>(name);
            var products = await _productRepository.GetEntities();

            if(_productLogic.HasExistingProductName(name, products))
                response.Errors.Add($"Product already exists: {name}");

            if(!_productLogic.HasValidName(name))
                response.Errors.Add($"Invalid product name: {name}");

            if (!response.Errors.Any())
                response.Data = await _productRepository.UpdateProductName(productId, name);

            return response;
        }
    }
}
