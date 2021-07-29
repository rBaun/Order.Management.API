using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PATCH
{
    public class UpdateCustomerFirstNameUseCase : IUpdateCustomerFirstNameUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerLogic _customerLogic;

        public UpdateCustomerFirstNameUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<string>> Execute(string customerId, string firstName)
        {
            var response = new Response<string>(firstName);

            if(!_customerLogic.HasValidFirstName(firstName))
                response.Errors.Add($"Invalid first name: {firstName}");

            if (!response.Errors.Any())
                response.Data = await _customerRepository.UpdateCustomerFirstName(customerId, firstName);

            return response;
        }
    }
}
