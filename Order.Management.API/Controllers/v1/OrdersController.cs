using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class OrdersController : BaseApiController<OrdersController>
    {
        public OrdersController(ILoggerManager logger) : base(logger)
        {
        }
    }
}
