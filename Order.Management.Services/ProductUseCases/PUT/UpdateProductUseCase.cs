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
        private readonly IProductRepository _productRepository;
        private readonly IProductLogic _productLogic;

        public UpdateProductUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public Task<Response<Product>> Execute(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
