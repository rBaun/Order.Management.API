using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class ProductsController : BaseApiController<ProductsController>
    {
        public ProductsController(ILoggerManager logger) : base(logger)
        {
        }
    }
}
