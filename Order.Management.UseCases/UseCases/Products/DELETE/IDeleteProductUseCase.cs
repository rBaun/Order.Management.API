using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.DELETE
{
    public interface IDeleteProductUseCase
    {
        Task<Response<Product>> Execute(string productId);
    }
}