using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.PUT
{
    public interface IUpdateCustomerUseCase
    {
        Task<Response<Customer>> Execute(Customer customer);
    }
}