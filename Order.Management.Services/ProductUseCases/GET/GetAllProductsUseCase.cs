using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.GET;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;
using OrderManagement.Persistence.EntityExtensions;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.ProductUseCases.GET
{
    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUriGenerator _uriGenerator;

        public GetAllProductsUseCase(IProductRepository productRepository, IUriGenerator uriGenerator)
        {
            _productRepository = productRepository;
            _uriGenerator = uriGenerator;
        }

        public async Task<PagedResponse<List<Product>>> Execute(PaginationFilter paginationFilter, string route)
        {
            var products = await _productRepository.GetEntities();
            var validatedFilter = PaginationHelper.ValidatePaginationFilter(paginationFilter);

            return products.CreateProductPagedResponse(validatedFilter, _uriGenerator, route);
        }
    }
}
