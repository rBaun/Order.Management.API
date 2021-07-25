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

            var response = await _customerService.CreateCustomer(customer);

            if (response.Errors.Any())
            {
                Logger.LogError("Customer not created");
                response.Message = "Customer not created. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customer created successfully!");


            return Created($"api/v1/customers/{response.Data.CustomerId}", response);
        }

        #endregion

        #region GET Requests

        // GET: api/v1/customers/{customerId}
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] string customerId)
        {
            Logger.LogInfo("Validating customer id...");
            if (string.IsNullOrWhiteSpace(customerId))
            {
                Logger.LogError("Invalid customer id");
                return BadRequest($"Invalid customer id: {customerId}");
            }

            Logger.LogInfo("Attempting to fetch customer record...");
            var response = await _customerService.GetCustomerById(customerId);

            if (response.Errors.Any())
            {
                Logger.LogWarn("Customer not found");
                response.Message = "Customer not found. Check the errors and try again.";
                response.Succeeded = false;
                return NotFound(response);
            }
            Logger.LogInfo("Customer found!");


            return Ok(response);
        }

        // GET: api/v1/customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all customers...");
            var response = await _customerService.GetAllCustomers(paginationFilter, Request.Path.Value);

            if (!response.Data.Any())
            {
                Logger.LogWarn("No Customers was found");
                response.Message = "No customers was found matching the criteria.";
                return Ok(response);
            }

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Customers not found. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customers found!");

            return Ok(response);
        }

        // GET: api/v1/customers/firstTimers
        [HttpGet("firstTimers")]
        public async Task<IActionResult> GetAllFirstTimeCustomers([FromQuery] PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all first-time customers...");
            var response = await _customerService.GetFirstTimeCustomers(paginationFilter, Request.Path.Value);

            if (!response.Data.Any())
            {
                Logger.LogWarn("No First-Time Customers was found");
                response.Message = "No First-Time Customers was found matching the criteria.";
                return Ok(response);
            }

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Customers not found. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customers found!");

            return Ok(response);
        }

        // GET: api/v1/customers/loyal
        [HttpGet("loyal")]
        public async Task<IActionResult> GetAllLoyalCustomers([FromQuery] PaginationFilter paginationFilter)
        {
            Logger.LogInfo("Fetching all loyal customers...");
            var response = await _customerService.GetLoyalCustomers(paginationFilter, Request.Path.Value);

            if (!response.Data.Any())
            {
                Logger.LogWarn("No Loyal Customers was found");
                response.Message = "No Loyal Customers was found matching the criteria.";
                return Ok(response);
            }

            if (response.Errors.Any())
            {
                Logger.LogError("Something went wrong");
                response.Message = "Customers not found. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customers found!");

            return Ok(response);
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

            var response = await _customerService.UpdateCustomer(customer);

            if (response.Errors.Any())
            {
                Logger.LogError("Customer not updated");
                response.Message = "Customer not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
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

            var response = await _customerService.UpdateCustomerAddressOn(customerId, address);

            if (response.Errors.Any())
            {
                Logger.LogError("Address not updated");
                response.Message = "Address not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Address updated successfully!");

            return Ok(response);
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

            var response = await _customerService.UpdateCustomerMailOn(customerId, mail);

            if (response.Errors.Any())
            {
                Logger.LogError("E-mail not updated");
                response.Message = "Mail not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Mail updated successfully!");

            return Ok(response);
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

            var response = await _customerService.UpdateCustomerNameOn(customerId, name);

            if (response.Errors.Any())
            {
                Logger.LogError("Name not updated");
                response.Message = "Name not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Name updated successfully!");

            return Ok(response);
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

            var response = await _customerService.UpdateCustomerStatusOn(customerId, customerStatus);

            if (response.Errors.Any())
            {
                Logger.LogError("Customer status not updated");
                response.Message = "Customer status not updated. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customer status updated successfully!");

            return Ok(response);
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

            var response = await _customerService.DeleteCustomer(customerId);

            if (response.Errors.Any())
            {
                Logger.LogError("Customer not deleted");
                response.Message = "Customer not removed. Check the errors and try again.";
                response.Succeeded = false;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            Logger.LogInfo("Customer deleted successfully!");

            return Ok(response);
        }

        #endregion
    }
}
