using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Persistence.EntityExtensions
{
    public static class ProductExtensions
    {
        public static List<Product> Search(this List<Product> products, string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? products
                : products.Where(product =>
                    product.Title.ToLower().Contains(searchTerm.Trim().ToLower())).ToList();
        }

        public static List<Product> Sort(this List<Product> products, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return products.OrderBy(product => product.Id).ToList();

            return orderBy.ToLower().Trim() switch
            {
                "title" => products.OrderBy(product => product.Title).ToList(),
                "category" => products.OrderBy(product => product.Category).ToList(),
                "price" => products.OrderBy(product => product.Price).ToList(),
                _ => products.OrderBy(product => product.Id).ToList()
            };
        }

        public static PagedResponse<List<Product>> CreateProductPagedResponse(this List<Product> pagedProducts,
            PaginationFilter validatedFilter, IUriGenerator uriGenerator, string route)
        {
            return PaginationHelper.CreatePagedResponse(pagedProducts
                .Search(validatedFilter.SearchTerm)
                .Sort(validatedFilter.OrderBy)
                .Skip((validatedFilter.PageNumber - 1) * validatedFilter.PageSize)
                .Take(validatedFilter.PageSize)
                .ToList(), validatedFilter, pagedProducts.Search(validatedFilter.SearchTerm).Count, uriGenerator, route);
        }
    }
}
