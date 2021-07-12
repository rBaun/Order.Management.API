using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class CustomersController : BaseApiController<CustomersController>
    {
        public CustomersController(ILoggerManager logger) : base(logger)
        {
        }
    }
}
