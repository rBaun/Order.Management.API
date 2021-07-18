using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.UseCases.Customers.POST
{
    public interface ICreateCustomerUseCase
    {
        Task<Customer> Execute(Customer customer);
    }
}
