using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
        protected ILoggerManager Logger { get; }

        protected BaseApiController(ILoggerManager logger)
        {
            Logger = logger;
        }
    }
}
