using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Products.POST;
using OrderManagement.Domain.Models;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class ProductsController : BaseApiController<ProductsController>
    {
        private readonly IProductService _productService;

        public ProductsController(ILoggerManager logger, IProductService productService) : base(logger)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
