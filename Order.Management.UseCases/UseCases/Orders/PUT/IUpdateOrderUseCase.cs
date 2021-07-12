using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.UseCases.Orders.PUT
{
    public interface IUpdateOrderUseCase
    {
        Task<Order> Execute(Order order);
    }
}
