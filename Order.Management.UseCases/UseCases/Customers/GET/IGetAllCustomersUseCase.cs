using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.UseCases.Customers.GET
{
    public interface IGetAllCustomersUseCase
    {
        Task<List<Customer>> Execute();
    }
}
