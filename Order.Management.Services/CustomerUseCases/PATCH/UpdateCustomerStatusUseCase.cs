using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PATCH
{
    public class UpdateCustomerStatusUseCase : IUpdateCustomerStatusUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerStatusUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<CustomerStatus>> Execute(string customerId, CustomerStatus customerStatus)
        {
            var response = new Response<CustomerStatus>(customerStatus)
            {
                Data = await _customerRepository.UpdateCustomerStatus(customerId, customerStatus)
            };

            return response;
        }
    }
}
