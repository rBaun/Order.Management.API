using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PUT;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PUT
{
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Response<Customer>> Execute(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
