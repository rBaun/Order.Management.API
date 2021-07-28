using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.PATCH
{
    public interface IUpdateProductStatusUseCase
    {
        Task<Response<ProductStatus>> Execute(string productId, ProductStatus productStatus);
    }
}
