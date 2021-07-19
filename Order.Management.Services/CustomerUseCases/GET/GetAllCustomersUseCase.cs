using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.GET;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.GET
{
    public class GetAllCustomersUseCase : IGetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Execute()
        {
            return await _customerRepository.GetEntities();
        }
    }
}
