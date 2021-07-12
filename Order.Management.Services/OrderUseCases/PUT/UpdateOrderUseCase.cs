using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Orders.PUT;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.OrderUseCases.PUT
{
    public class UpdateOrderUseCase : IUpdateOrderUseCase
    {
        Task<Order> IUpdateOrderUseCase.Execute(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
