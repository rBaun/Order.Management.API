using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Application.UseCases.Products.POST;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

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

        // POST: api/v1/products/add
        [HttpPost("add")]
        public IActionResult CreateProduct([FromQuery] Product product)
        {
            Logger.LogInfo("Validating product details...");
            if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Brand) ||
                string.IsNullOrWhiteSpace(product.Description) || product.Stock < 0 || product.Price < 0)
            {
                Logger.LogError($"Product invalid.");
                return BadRequest("Product invalid");
            }

            Logger.LogInfo("Attempting to create product...");
            var createdProduct = _productService.CreateProduct(product);

            if (createdProduct?.ProductId < 1)
            {
                Logger.LogError("Product not created.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Product not created");
            }
            Logger.LogInfo("Product created successfully!");

            return Created($"api/v1/products/{createdProduct?.ProductId}", new Response<Product>(createdProduct));
        }
    }
}
