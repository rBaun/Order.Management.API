using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using OrderManagement.Domain.Wrappers.Pagination;

namespace OrderManagement.Domain.Helpers
{
    public interface IUriGenerator
    {
        Uri GetPageUri(PaginationFilter paginationFilter, string route);
    }

    public class UriGenerator : IUriGenerator
    {
        private readonly string _baseUri;

        public UriGenerator(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter paginationFilter, string route)
        {
            var endpointUri = new Uri(string.Concat(_baseUri, route));
            var queryStringParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationFilter.PageNumber.ToString(),
                ["pageSize"] = paginationFilter.PageSize.ToString()
            };

            return new Uri(QueryHelpers.AddQueryString(endpointUri.ToString(), queryStringParameters));
        }
    }
}