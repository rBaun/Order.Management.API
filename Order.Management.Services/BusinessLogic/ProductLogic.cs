using System;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        public Product ProductIsInStock(Product product)
        {
            if (product == null)
                return null;

            if (product.Stock > 0)
                product.ProductStatus = ProductStatus.InStock;

            return product;
        }

        public bool ValidateProductDetails(Product product)
        {
            if (product == null)
                return false;

            return !string.IsNullOrWhiteSpace(product.Name) && product.Name.Length >= 2;
        }

        public bool ProductHasImage(Product product)
        {
            return product != null && string.IsNullOrWhiteSpace(product.ImageUrl);
        }

        public Product CheckIfProductIsNew(Product product)
        {
            if (product == null)
                return null;

            if (DateTime.Now.AddDays(-7) < product.CreatedOn)
                product.IsNew = true;

            return product;
        }
    }
}
