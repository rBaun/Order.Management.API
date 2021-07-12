using OrderManagement.Domain.Models;

namespace OrderManagement.Services.BusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        Product ProductIsInStock(Product product);
        bool ValidateProductDetails(Product product);
        bool ProductHasImage(Product product);
        Product CheckIfProductIsNew(Product product);
    }
}
