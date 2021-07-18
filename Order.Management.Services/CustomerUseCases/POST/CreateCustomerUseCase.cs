using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.POST;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
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

        public async Task<Customer> Execute(Customer customer)
        {
            if (!await _customerLogic.ValidateCustomerEmail(customer.Mail))
                return null;

            if (!await _customerLogic.ValidateCustomerPhone(customer.Phone))
                return null;

            if (!await _customerLogic.ValidateRequiredCustomerFields(customer))
                return null;

            customer.CustomerStatus = CustomerStatus.Customer;

            return await _customerRepository.CreateEntity(customer);
        }
    }
}
