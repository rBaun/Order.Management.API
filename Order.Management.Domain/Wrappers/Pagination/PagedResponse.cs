using System;
using System.Collections.Generic;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Domain.Wrappers.Pagination
{
    public class PagedResponse<T> : Response<T>
    {
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Succeeded = true;
            Errors = new List<string>();
            Message = string.Empty;
        }

        public PagedResponse(int pageNumber, int pageSize)
        {
            Errors = new List<string>();
        }

        public PagedResponse()
        {
            Errors = new List<string>();
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri CurrentPage { get; set; }
        public Uri PreviousPage { get; set; }
    }
}