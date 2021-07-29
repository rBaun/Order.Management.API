using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.PATCH
{
    public interface IUpdateCustomerStatusUseCase
    {
        Task<Response<CustomerStatus>> Execute(string customerId, CustomerStatus customerStatus);
    }
}
