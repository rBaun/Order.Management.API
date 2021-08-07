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
    public static class OrderExtensions
    {
        public static List<Order> Search(this List<Order> orders, string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? orders
                : orders.Where(order =>
                    order.OrderId.ToLower().Contains(searchTerm.Trim().ToLower())).ToList();
        }

        public static List<Order> Sort(this List<Order> orders, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return orders.OrderBy(order => order.PlacedOn).ToList();

            return orderBy.ToLower().Trim() switch
            {
                "price" => orders.OrderBy(order => order.TotalPrice).ToList(),
                "status" => orders.OrderBy(order => order.OrderStatus).ToList(),
                "address" => orders.OrderBy(order => order.Customer.Address).ToList(),
                _ => orders.OrderBy(order => order.PlacedOn).ToList()
            };
        }

        public static PagedResponse<List<Order>> CreateOrderPagedResponse(this List<Order> pagedOrders,
            PaginationFilter validatedFilter, IUriGenerator uriGenerator, string route)
        {
            return PaginationHelper.CreatePagedResponse(pagedOrders
                    .Search(validatedFilter.SearchTerm)
                    .Sort(validatedFilter.OrderBy)
                    .Skip((validatedFilter.PageNumber - 1) * validatedFilter.PageSize)
                    .Take(validatedFilter.PageSize)
                    .ToList(), validatedFilter, pagedOrders.Search(validatedFilter.SearchTerm).Count, uriGenerator,
                route);
        }
    }
}
