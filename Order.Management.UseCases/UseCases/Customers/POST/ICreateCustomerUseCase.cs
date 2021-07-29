using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.POST
{
    public interface ICreateCustomerUseCase
    {
        Task<Response<Customer>> Execute(Customer customer);
    }
}