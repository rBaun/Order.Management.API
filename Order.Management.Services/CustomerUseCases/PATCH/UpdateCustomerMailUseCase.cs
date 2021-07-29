using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Customers.PATCH;
using OrderManagement.Domain.Wrappers.Common;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.CustomerUseCases.PATCH
{
    public class UpdateCustomerMailUseCase : IUpdateCustomerMailUseCase
    {
        private readonly ICustomerLogic _customerLogic;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerMailUseCase(ICustomerRepository customerRepository, ICustomerLogic customerLogic)
        {
            _customerRepository = customerRepository;
            _customerLogic = customerLogic;
        }

        public async Task<Response<string>> Execute(string customerId, string mail)
        {
            var response = new Response<string>(mail);
            var customers = await _customerRepository.GetEntities();

            if (_customerLogic.HasExistingMail(mail, customers))
                response.Errors.Add($"Invalid mail: {mail}");

            if (!_customerLogic.HasValidMail(mail))
                response.Errors.Add($"Invalid mail format: {mail}");

            if (!response.Errors.Any())
                response.Data = await _customerRepository.UpdateCustomerMail(customerId, mail);

            return response;
        }
    }
}