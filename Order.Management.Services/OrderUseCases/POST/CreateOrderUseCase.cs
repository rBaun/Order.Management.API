using System.Threading.Tasks;
using OrderManagement.Application.UseCases.Orders.POST;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.OrderUseCases.POST
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        public Task<Order> Execute(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
