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
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerLogic _customerLogic;

        public UpdateCustomerAddressUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<string>> Execute(string customerId, string newAddress)
        {
            var response = new Response<string>(newAddress);

            if(!_customerLogic.HasValidAddress(newAddress))
                response.Errors.Add($"Address invalid: {newAddress}");

            if(!response.Errors.Any())
                response.Data = await _customerRepository.UpdateCustomerAddress(customerId, newAddress);

            return response;
        }
    }
}
