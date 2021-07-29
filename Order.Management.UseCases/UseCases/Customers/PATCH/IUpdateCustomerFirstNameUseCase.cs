using System.Threading.Tasks;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.PATCH
{
    public interface IUpdateCustomerFirstNameUseCase
    {
        Task<Response<string>> Execute(string customerId, string firstName);
    }
}
