using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.DELETE;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.DELETE
{
    public class DeleteCustomerUseCase : IDeleteCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<Customer>> Execute(string customerId)
        {
            // TODO: Some authentication logic? Only admins should be able to perform this action
            var customer = await _customerRepository.GetEntityById(customerId);
            var response = new Response<Customer>(customer);

            if(response.Data == null)
                response.Errors.Add("No customer found");

            if(!response.Errors.Any())
                response.Data = await _customerRepository.DeleteEntity(customerId);

            return response;
        }
    }
}
