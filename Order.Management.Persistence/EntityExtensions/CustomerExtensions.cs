using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.EntityExtensions
{
    public static class CustomerExtensions
    {
        public static List<Customer> Search(this List<Customer> customers, string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? customers
                : customers.Where(customer =>
                    customer.FirstName.ToLower().Contains(searchTerm.Trim().ToLower()) ||
                    customer.LastName.ToLower().Contains(searchTerm.Trim().ToLower())).ToList();
        }

        public static List<Customer> Sort(this List<Customer> customers, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return customers.OrderBy(customer => customer.LastName).ToList();

            return orderBy.ToLower().Trim() switch
            {
                "firstName" => customers.OrderBy(customer => customer.FirstName).ToList(),
                "mail" => customers.OrderBy(customer => customer.Mail).ToList(),
                "phone" => customers.OrderBy(customer => customer.Phone).ToList(),
                _ => customers.OrderBy(customer => customer.LastName).ToList(),
            };
        }
    }
}
