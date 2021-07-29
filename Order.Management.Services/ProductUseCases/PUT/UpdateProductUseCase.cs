using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.PUT;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.ProductUseCases.PUT
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductLogic _productLogic;
        private readonly IProductRepository _productRepository;

        public UpdateProductUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public async Task<Response<Product>> Execute(Product product)
        {
            var response = new Response<Product>(product);
            var products = await _productRepository.GetEntities();

            if (_productLogic.HasExistingProductName(product.Title, products))
                response.Errors.Add($"Product already exists: {product.Title}");

            if (!_productLogic.HasValidName(product.Title))
                response.Errors.Add($"Invalid product name: {product.Title}");

            if (!_productLogic.HasValidStock(product.Stock))
                response.Errors.Add($"Invalid product stock: {product.Stock}");

            if (!_productLogic.HasValidPrice(product.Price))
                response.Errors.Add($"Invalid product price: {product.Price}");

            if (!response.Errors.Any())
                response.Data = await _productRepository.UpdateEntity(product);

            return response;
        }
    }
}