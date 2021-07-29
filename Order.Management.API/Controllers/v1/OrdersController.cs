using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class OrdersController : BaseApiController<OrdersController>
    {
        private readonly IOrderService _orderService;

        public OrdersController(ILoggerManager logger, IOrderService orderService) : base(logger)
        {
            _orderService = orderService;
        }
    }
}