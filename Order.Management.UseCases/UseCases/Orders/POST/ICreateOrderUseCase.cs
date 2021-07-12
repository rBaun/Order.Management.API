using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.UseCases.Orders.POST
{
    public interface ICreateOrderUseCase
    {
        Task<Order> Execute(Order order);
    }
}
