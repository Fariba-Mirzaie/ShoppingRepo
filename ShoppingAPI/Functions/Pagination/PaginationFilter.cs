namespace ShoppingAPI.Functions.Pagination
{
    public class PaginationFilter
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }

        public PaginationFilter()
        {
            this.pageNumber = 1;
            this.pageSize = 3;
        }
       public PaginationFilter(int pageNumber, int pageSize, int pageCount)
        {
            this.pageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.pageSize = pageSize > 5 ? 5 : pageSize;
            this.pageCount =(int)Math.Ceiling((double)pageCount);
        }
    }
}
