using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Domain.Wrappers.Pagination;

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

        // POST: api/v1/customers/add
        [HttpPost("add")]
        public IActionResult CreateCustomer([FromQuery] Customer customer)
        {
            Logger.LogInfo("Validating customer details...");
            // TODO: FirstName, LastName, Address and E-mail is not empty or whitespace

            Logger.LogInfo("Checking if customer exists...");
            // TODO: Check if E-mail and Phone exists in the database

            Logger.LogInfo("Attempting to create customer...");
            var createdCustomer = _customerService.CreateCustomer(customer);

            if (createdCustomer?.CustomerId < 1)
            {
                Logger.LogError("Customer not created");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer not created");
            }
            Logger.LogInfo("Customer created successfully!");


            return Created($"api/v1/customers/{createdCustomer?.CustomerId}", new Response<Customer>(createdCustomer));
        }

        // GET: api/v1/customers/{customerId}
        [HttpGet("{customerId:int}")]
        public IActionResult GetCustomerById([FromRoute] int customerId)
        {
            Logger.LogInfo("Validating customer id...");
            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest($"Invalid customer id: {customerId}");
            }

            Logger.LogInfo("Attempting to fetch customer record...");
            var customer = _customerService.GetCustomerById(customerId);

            if (customer.CustomerId != customerId)
            {
                Logger.LogWarn("Customer not found");
                return NotFound(customerId);
            }
            Logger.LogInfo("Customer found!");


            return Ok(customer);
        }

        // GET: api/v1/customers
        [HttpGet]
        public IActionResult GetAllCustomers(PaginationFilter paginationFilter)
        {
            var customers = _customerService.GetAllCustomers(paginationFilter, Request.Path.Value);

            return Ok(customers);
        }
    }
}
