using System;
using System.Collections.Generic;
using OrderManagement.Domain.Helpers;
using OrderManagement.Domain.Models;

namespace OrderManagement.Domain.Wrappers.Pagination
{
    public class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pagedData, PaginationFilter validFilter,
            int totalRecords, IUriGenerator uriGenerator, string route)
        {
            var totalPages = Convert.ToInt32(Math.Ceiling((double) totalRecords / validFilter.PageSize));
            var response = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize)
            {
                NextPage =
                    validFilter.PageNumber >= 1 && validFilter.PageNumber < totalPages
                        ? uriGenerator.GetPageUri(
                            new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                        : null,
                PreviousPage =
                    validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= totalPages
                        ? uriGenerator.GetPageUri(
                            new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                        : null,
                FirstPage = uriGenerator.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route),
                LastPage = uriGenerator.GetPageUri(new PaginationFilter(totalPages, validFilter.PageSize), route),
                CurrentPage =
                    uriGenerator.GetPageUri(new PaginationFilter(validFilter.PageNumber, validFilter.PageSize), route),
                TotalPages = totalPages,
                TotalRecords = totalRecords
            };

            return response;
        }

        public static PaginationFilter ValidatePaginationFilter(PaginationFilter paginationFilter)
        {
            // The constructor makes sure the filter is valid
            return new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize,
                paginationFilter.SearchTerm, paginationFilter.OrderBy);
        }
    }
}
