using System;
using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool HasValidStock(int stock)
        {
            if (stock < 0)
                return false;

            if (stock > 999)
                return false;

            return true;
        }

        public bool HasValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (name.Length < 2)
                return false;

            return true;
        }

        public bool HasExistingProductName(string name, List<Product> products)
        {
            return products.Exists(product =>
                string.Equals(product.Title, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool HasValidPrice(double price)
        {
            return price > 0;
        }

        public ProductStatus SetProductStockStatus(Product product)
        {
            return product.Stock == 0
                ? ProductStatus.OutOfStock
                : ProductStatus.InStock;
        }
    }
}