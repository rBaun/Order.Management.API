using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
        protected readonly ILoggerManager _logger;

        protected BaseApiController(ILoggerManager logger)
        {
            _logger = logger;
        }
    }
}
