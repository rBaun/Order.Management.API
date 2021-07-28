using System.Threading.Tasks;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.PATCH
{
    public interface IUpdateProductNameUseCase
    {
        Task<Response<string>> Execute(string productId, string name);
    }
}
