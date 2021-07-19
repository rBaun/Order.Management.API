using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Extensions.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Enums;
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

        #region POST Requests

        // POST: api/v1/customers/add
        [HttpPost("add")]
        public async Task<IActionResult> CreateCustomer([FromQuery] Customer customer)
        {
            Logger.LogInfo("Attempting to create customer...");

            if (customer == null)
                return BadRequest();

            var createdCustomer = await _customerService.CreateCustomer(customer);

            if (createdCustomer?.CustomerId != null)
            {
                Logger.LogError("Customer not created");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer not created");
            }
            Logger.LogInfo("Customer created successfully!");


            return Created($"api/v1/customers/{createdCustomer?.CustomerId}", new Response<Customer>(createdCustomer));
        }

        #endregion

        #region GET Requests

        // GET: api/v1/customers/{customerId}
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] string customerId)
        {
            Logger.LogInfo("Validating customer id...");
            if (string.IsNullOrWhiteSpace(customerId))
            {
                Logger.LogError("Invalid customer id");
                return BadRequest($"Invalid customer id: {customerId}");
            }

            Logger.LogInfo("Attempting to fetch customer record...");
            var customer = await _customerService.GetCustomerById(customerId);

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
        public async Task<IActionResult> GetAllCustomers(PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all customers...");
            var customers = await _customerService.GetAllCustomers(paginationFilter, Request.Path.Value);
            Logger.LogInfo("Customers found!");

            return Ok(customers);
        }

        // GET: api/v1/customers/firstTimers
        [HttpGet("firstTimers")]
        public async Task<IActionResult> GetAllFirstTimeCustomers(PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all first-time customers...");
            var customers = await _customerService.GetFirstTimeCustomers(paginationFilter, Request.Path.Value);
            Logger.LogInfo("Customers found!");

            return Ok(customers);
        }

        // GET: api/v1/customers/loyal
        [HttpGet("loyal")]
        public async Task<IActionResult> GetAllLoyalCustomers(PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all loyal customers...");
            var customers = await _customerService.GetLoyalCustomers(paginationFilter, Request.Path.Value);
            Logger.LogInfo("Customers found!");

            return Ok(customers);
        }

        // GET: api/v1/customers/noAccount
        [HttpGet("noAccount")]
        public async Task<IActionResult> GetAllNoAccountCustomers(PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all customers without accounts...");
            var customers = await _customerService.GetNoAccountCustomers(paginationFilter, Request.Path.Value);
            Logger.LogInfo("Customers found!");

            return Ok(customers);
        }

        #endregion

        #region PUT Requests

        // PUT: api/v1/customers
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromQuery] Customer customer)
        {
            Logger.LogInfo("Attempting to update customer...");

            if (string.IsNullOrWhiteSpace(customer.CustomerId))
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customer);
            }

            var updatedCustomer = await _customerService.UpdateCustomer(customer);

            if (updatedCustomer != customer)
            {
                Logger.LogError("Customer not updated");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer not updated");
            }
            Logger.LogInfo("Customer updated successfully!");

            return Ok(customer);
        }

        #endregion

        #region PATCH Requests

        // PATCH: api/v1/customers/update/address
        [HttpPatch("update/address")]
        public async Task<IActionResult> PatchCustomerAddress(int customerId, string address)
        {
            Logger.LogInfo("Attempting to update customer address...");

            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customerId);
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                Logger.LogError("Invalid customer address");
                return BadRequest(address);
            }

            var updatedCustomer = await _customerService.UpdateCustomerAddressOn(customerId, address);

            if (updatedCustomer.Address != address)
            {
                Logger.LogError("Address not updated");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer address not updated");
            } 
            Logger.LogInfo("Address updated successfully!");

            return Ok(updatedCustomer);
        }

        // PATCH: api/v1/customers/update/mail
        [HttpPatch("update/mail")]
        public async Task<IActionResult> PatchCustomerMail(int customerId, string mail)
        {
            Logger.LogInfo("Attempting to update customer e-mail...");

            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customerId);
            }

            if (string.IsNullOrWhiteSpace(mail))
            {
                Logger.LogError("Invalid customer mail");
                return BadRequest(mail);
            }

            var updatedCustomer = await _customerService.UpdateCustomerMailOn(customerId, mail);

            if (updatedCustomer.Mail != mail)
            {
                Logger.LogError("E-mail not updated");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer mail not updated");
            }
            Logger.LogInfo("Mail updated successfully!");    

            return Ok(updatedCustomer);
        }

        // PATCH: api/v1/customers/update/name
        [HttpPatch("update/name")]
        public async Task<IActionResult> PatchCustomerName(int customerId, string name)
        {
            Logger.LogInfo("Attempting to update customer name...");

            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customerId);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                Logger.LogError("Invalid customer name");
                return BadRequest(name);
            }

            var updatedCustomer = await _customerService.UpdateCustomerNameOn(customerId, name);

            if (updatedCustomer.Mail != name)
            {
                Logger.LogError("Name not updated");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer name not updated");
            }
            Logger.LogInfo("Name updated successfully!");

            return Ok(updatedCustomer);
        }

        // PATCH: api/v1/customers/update/status
        [HttpPatch("update/status")]
        public async Task<IActionResult> PatchCustomerStatus(int customerId, CustomerStatus customerStatus)
        {
            Logger.LogInfo("Attempting to update customer status...");

            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customerId);
            }

            var updatedCustomer = await _customerService.UpdateCustomerStatusOn(customerId, customerStatus);

            if (updatedCustomer.CustomerStatus != customerStatus)
            {
                Logger.LogError("Customer status not updated");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer status not updated");
            }
            Logger.LogInfo("Customer status updated successfully!");
            
            return Ok(updatedCustomer);
        }

        #endregion

        #region DELETE Requests

        // DELETE: api/v1/customers
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            Logger.LogInfo("Attempting to delete customer...");

            if (customerId < 1)
            {
                Logger.LogError("Invalid customer id");
                return BadRequest(customerId);
            }

            var deletedCustomerId = await _customerService.DeleteCustomer(customerId);

            if (deletedCustomerId != customerId)
            {
                Logger.LogError("Customer not deleted");
                return StatusCode(StatusCodes.Status500InternalServerError, "Customer not deleted");
            }
            Logger.LogInfo("Customer deleted successfully!");

            return Ok(deletedCustomerId);
        }

        #endregion
    }
}
