using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.GET
{
    public interface IGetCustomerByIdUseCase
    {
        Task<Response<Customer>> Execute(string id);
    }
}