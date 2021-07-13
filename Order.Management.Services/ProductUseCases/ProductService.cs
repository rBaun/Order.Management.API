using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.ProductUseCases
{
    public class ProductService : IProductService
    {
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTop10Products()
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProductDescription(int productId, string description)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProductName(int productId, string name)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProductStatusOn(int productId, ProductStatus productStatus)
        {
            throw new NotImplementedException();
        }

        public int DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
