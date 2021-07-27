using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.POST
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerLogic _customerLogic;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerLogic customerLogic, ICustomerRepository customerRepository)
        {
            _customerLogic = customerLogic;
            _customerRepository = customerRepository;
        }

        public async Task<Response<Customer>> Execute(Customer customer)
        {
            var response = new Response<Customer>(customer);
            var allCustomers = await _customerRepository.GetEntities();

            if (_customerLogic.HasExistingMail(customer.Mail, allCustomers))
                response.Errors.Add($"Mail address invalid: {customer.Mail}");

            if (_customerLogic.HasExistingPhone(customer.Phone, allCustomers))
                response.Errors.Add($"Phone number invalid: {customer.Phone}");

            if (!_customerLogic.HasRequiredCustomerFields(customer))
                response.Errors.Add("Required customer fields invalid");

            if (!response.Errors.Any())
            {
                response.Data.CustomerStatus = CustomerStatus.Customer;
                response.Data = await _customerRepository.CreateEntity(response.Data);
            }

            return response;
        }
    }
}
