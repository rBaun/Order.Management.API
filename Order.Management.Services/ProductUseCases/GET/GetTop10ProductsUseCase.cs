using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Products.GET;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.ProductUseCases.GET
{
    public class GetTop10ProductsUseCase : IGetTop10ProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetTop10ProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Response<List<Product>>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}