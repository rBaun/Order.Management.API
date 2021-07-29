using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.POST
{
    public interface ICreateProductUseCase
    {
        Task<Response<Product>> Execute(Product product);
    }
}