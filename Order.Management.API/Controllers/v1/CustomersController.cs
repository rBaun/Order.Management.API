using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;

namespace OrderManagement.API.Controllers.v1
{
    [ApiController]
    public class CustomersController : BaseApiController<CustomersController>
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ILoggerManager logger, ICustomerService customerService) : base(logger)
        {
            _customerService = customerService;
        }
    }
}
