using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.DELETE
{
    public interface IDeleteCustomerUseCase
    {
        Task<Response<Customer>> Execute(string customerId);
    }
}