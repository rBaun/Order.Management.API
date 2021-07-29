using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.GET;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.ProductUseCases.GET
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<Product>> Execute(string productId)
        {
            var product = await _productRepository.GetEntityById(productId);
            var response = new Response<Product>(product);

            if (response.Data == null)
                response.Errors.Add($"Found no customer with id of '{productId}'");

            return response;
        }
    }
}