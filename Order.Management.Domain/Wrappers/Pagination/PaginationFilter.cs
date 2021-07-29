namespace OrderManagement.Domain.Wrappers.Pagination
{
    public class PaginationFilter
    {
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;
        private const int PageSizeCap = 50;

        public PaginationFilter()
        {
            PageNumber = DefaultPageNumber;
            PageSize = DefaultPageSize;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = SetPageNumber(pageNumber);
            PageSize = SetPageSize(pageSize);
        }

        public PaginationFilter(int pageNumber, int pageSize, string searchTerm, string orderBy)
        {
            PageNumber = SetPageNumber(pageNumber);
            PageSize = SetPageSize(pageSize);
            SearchTerm = searchTerm;
            OrderBy = orderBy;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
        public string OrderBy { get; set; }

        private static int SetPageNumber(int pageNumber)
        {
            return pageNumber < 1 ? 1 : pageNumber;
        }

        private static int SetPageSize(int pageSize)
        {
            return pageSize > PageSizeCap || pageSize == 0 ? PageSizeCap : pageSize;
        }
    }
}