using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;
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
            Logger.LogInfo("Validating product details...");
            if (!string.IsNullOrWhiteSpace(product.Name) || !string.IsNullOrWhiteSpace(product.Brand) ||
                !string.IsNullOrWhiteSpace(product.Description) || product.Stock < 0 || product.Price < 0)
            {
                Logger.LogError($"Product failed validation.");
                return BadRequest(product);
            }

            Logger.LogInfo("Starting to create product...");
            var createdProduct = _productService.CreateProduct(product);

            if (createdProduct.ProductId > 0)
            {
                Logger.LogInfo("Product was created successfully!");
            }
            else
            {
                Logger.LogError("Product was not created. The returned ID was NOT above 0.");
            }

            return Ok(createdProduct);
        }
    }
}
