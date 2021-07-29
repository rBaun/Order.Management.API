using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.PUT
{
    public interface IUpdateProductUseCase
    {
        Task<Response<Product>> Execute(Product product);
    }
}