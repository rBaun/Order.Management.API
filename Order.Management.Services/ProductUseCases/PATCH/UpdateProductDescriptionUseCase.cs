using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.ProductUseCases.PATCH
{
    public class UpdateProductDescriptionUseCase : IUpdateProductDescriptionUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductLogic _productLogic;

        public UpdateProductDescriptionUseCase(IProductRepository productRepository, IProductLogic productLogic)
        {
            _productRepository = productRepository;
            _productLogic = productLogic;
        }

        public Task<Response<string>> Execute(string productId, string description)
        {
            throw new System.NotImplementedException();
        }
    }
}
