using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.BusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        bool HasValidStock(int stock);
        bool HasValidName(string name);
        bool HasExistingProductName(string name, List<Product> products);
        bool HasValidPrice(double price);
        ProductStatus SetProductStockStatus(Product product);
    }
}