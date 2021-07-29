using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

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

        #region POST Requests

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

        #endregion

        #region PUT Requests

        // PUT: api/v1/products
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromQuery] Product product)
        {
            Logger.LogInfo("Attempting to update product...");

            if (string.IsNullOrWhiteSpace(product.ProductId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest(product);
            }

            var response = await _productService.UpdateProduct(product);

            if (response.Errors.Any())
            {
                Logger.LogError("Product not updated");
                response.Message = "Product not updated. Check the errors and try again";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Product updated successfully!");

            return Ok(response);
        }

        #endregion

        #region DELETE Requests

        // DELETE: api/v1/products/{productId}
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(string productId)
        {
            Logger.LogInfo("Attempting to delete product...");

            if (string.IsNullOrWhiteSpace(productId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest(productId);
            }

            var response = await _productService.DeleteProduct(productId);

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Product not removed. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Product deleted successfully!");

            return Ok(response);
        }

        #endregion

        #region GET Requests

        // GET: api/v1/products/{productId}
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            Logger.LogInfo("Fetching customer record...");
            if (string.IsNullOrWhiteSpace(productId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest();
            }

            var response = await _productService.GetProductById(productId);

            if (response.Errors.Any())
            {
                Logger.LogWarn("Product not found");
                response.Message = "Product not found. Check the errors and try again";
                response.Succeeded = false;
                return NotFound(response);
            }

            Logger.LogInfo("Product found!");

            return Ok(response);
        }

        // GET: api/v1/products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching customer records...");
            var response = await _productService.GetAllProducts(paginationFilter, Request.Path.Value);

            if (!response.Data.Any())
            {
                Logger.LogWarn("No Products was found");
                response.Message = "No products found matching the criteria.";
                return Ok(response);
            }

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Products not found. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Products found!");

            return Ok(response);
        }

        // GET: api/v1/products/top10
        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10Products()
        {
            Logger.LogInfo("Fetching 10 most popular products...");
            var response = await _productService.GetTop10Products();

            if (!response.Data.Any())
            {
                Logger.LogWarn("No popular products was found");
                response.Message = "No popular products was found in the process.";
                return Ok(response);
            }

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Popular products not found. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Popular products found!");

            return Ok(response);
        }

        #endregion

        #region PATCH Requests

        // PATCH: api/v1/products/update/description
        [HttpPatch("update/description")]
        public async Task<IActionResult> UpdateProductDescription(string productId, string description)
        {
            Logger.LogInfo("Attempting to update product description...");

            if (string.IsNullOrWhiteSpace(productId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest(productId);
            }

            var response = await _productService.UpdateProductDescription(productId, description);

            if (response.Errors.Any())
            {
                Logger.LogError("Product Description not updated");
                response.Message = "Product Description not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Product Description updated successfully!");

            return Ok(response);
        }

        // PATCH: api/v1/products/update/name
        [HttpPatch("update/name")]
        public async Task<IActionResult> UpdateProductName(string productId, string name)
        {
            Logger.LogInfo("Attempting to update product title...");

            if (string.IsNullOrWhiteSpace(productId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest(productId);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.LogError("Invalid product title");
                return BadRequest(name);
            }

            var response = await _productService.UpdateProductName(productId, name);

            if (response.Errors.Any())
            {
                Logger.LogError("Product Title not updated");
                response.Message = "Product Title not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Product Title updated successfully!");

            return Ok(response);
        }

        // PATCH: api/v1/products/update/status
        [HttpPatch("update/status")]
        public async Task<IActionResult> UpdateProductStatus(string productId, ProductStatus productStatus)
        {
            Logger.LogInfo("Attempting to update product status...");

            if (string.IsNullOrWhiteSpace(productId))
            {
                Logger.LogError("Invalid product id");
                return BadRequest(productId);
            }

            var response = await _productService.UpdateProductStatusOn(productId, productStatus);

            if (response.Errors.Any())
            {
                Logger.LogError("Product Status not updated");
                response.Message = "Product Status not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            Logger.LogInfo("Product Status updated successfully!");

            return Ok(response);
        }

        #endregion
    }
}