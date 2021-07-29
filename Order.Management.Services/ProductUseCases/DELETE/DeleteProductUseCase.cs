using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.DELETE;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.ProductUseCases.DELETE
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<Product>> Execute(string productId)
        {
            var product = await _productRepository.GetEntityById(productId);
            var response = new Response<Product>(product);

            if(response.Data == null)
                response.Errors.Add("No product found");

            if (!response.Errors.Any())
                response.Data = await _productRepository.DeleteEntity(productId);

            return response;
        }
    }
}