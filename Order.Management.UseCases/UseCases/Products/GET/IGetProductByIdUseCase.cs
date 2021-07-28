using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.GET
{
    public interface IGetProductByIdUseCase
    {
        Task<Response<Product>> Execute(string productId);
    }
}
