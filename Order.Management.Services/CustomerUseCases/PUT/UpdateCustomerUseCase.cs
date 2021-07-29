using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PUT;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PUT
{
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomerLogic _customerLogic;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<Customer>> Execute(Customer customer)
        {
            var response = new Response<Customer>(customer);
            var customers = await _customerRepository.GetEntities();

            if (_customerLogic.HasExistingMail(customer.Mail, customers))
                response.Errors.Add($"Mail address invalid: {customer.Mail}");

            if (_customerLogic.HasExistingPhone(customer.Phone, customers))
                response.Errors.Add($"Phone number invalid: {customer.Phone}");

            if (!_customerLogic.HasRequiredCustomerFields(customer))
                response.Errors.Add("Required customer fields invalid");

            if (!response.Errors.Any())
                response.Data = await _customerRepository.UpdateEntity(customer);

            return response;
        }
    }
}