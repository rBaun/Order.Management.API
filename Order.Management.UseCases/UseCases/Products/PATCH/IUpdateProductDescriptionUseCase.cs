using System.Threading.Tasks;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.PATCH
{
    public interface IUpdateProductDescriptionUseCase
    {
        Task<Response<string>> Execute(string productId, string description);
    }
}
