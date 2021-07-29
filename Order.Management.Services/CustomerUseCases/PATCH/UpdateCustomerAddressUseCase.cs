using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PATCH
{
    public class UpdateCustomerAddressUseCase : IUpdateCustomerAddressUseCase
    {
        private readonly ICustomerLogic _customerLogic;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerAddressUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<string>> Execute(string customerId, string address)
        {
            var response = new Response<string>(address);

            if (!_customerLogic.HasValidAddress(address))
                response.Errors.Add($"Address invalid: {address}");

            if (!response.Errors.Any())
                response.Data = await _customerRepository.UpdateCustomerAddress(customerId, address);

            return response;
        }
    }
}