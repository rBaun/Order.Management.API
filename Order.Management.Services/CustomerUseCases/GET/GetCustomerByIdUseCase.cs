using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.GET
{
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<Customer>> Execute(string id)
        {
            var customer = await _customerRepository.GetEntityById(id);
            var response = new Response<Customer>(customer);

            if (response.Data == null)
                response.Errors.Add($"Found no customer with id of '{id}'");

            return response;
        }
    }
}