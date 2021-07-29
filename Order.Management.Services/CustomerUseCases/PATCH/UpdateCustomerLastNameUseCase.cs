using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PATCH
{
    public class UpdateCustomerLastNameUseCase : IUpdateCustomerLastNameUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerLogic _customerLogic;

        public UpdateCustomerLastNameUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<string>> Execute(string customerId, string lastName)
        {
            var response = new Response<string>(lastName);

            if(!_customerLogic.HasValidLastName(lastName))
                response.Errors.Add($"Invalid last name: {lastName}");

            if (!response.Errors.Any())
                response.Data = await _customerRepository.UpdateCustomerLastName(customerId, lastName);

            return response;
        }
    }
}
