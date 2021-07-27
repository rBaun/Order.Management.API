using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
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
        public async Task<IActionResult> CreateProduct([FromQuery] Product product)
        {
            Logger.LogInfo("Attempting to create product...");

            if (product == null)
                return BadRequest();

            var response = await _productService.CreateProduct(product);

            if (response.Errors.Any())
            {
                Logger.LogError("Product not created");
                response.Message = "Product not created. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Product created Successfully!");

            return Created($"api/v1/products/{response.Data.ProductId}", response);
        }
    }
}
