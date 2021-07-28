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

        public Task<Response<Product>> Execute(string productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
