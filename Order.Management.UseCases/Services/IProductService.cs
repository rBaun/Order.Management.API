using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Application.Services
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        List<Product> GetTop10Products();
        Product UpdateProduct(Product product);
        Product UpdateProductDescription(int productId, string description);
        Product UpdateProductName(int productId, string name);
        Product UpdateProductStatusOn(int productId, ProductStatus productStatus);
        int DeleteProduct(int productId);
    }
}
