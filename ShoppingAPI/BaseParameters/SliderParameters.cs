namespace ShoppingAPI.BaseParameters
{
    public class SliderParameters : ISliderParameters
    {
        public string? Title { get; set; }
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 3;
        public int pageCount { get; set; }
        public SortType Type { get; set; }

        public enum SortType { Asc, Desc }

        public void Pagination(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.pageSize = pageSize > 5 ? 5 : pageSize;
            //this.pageCount = (int)Math.Ceiling((double)pageCount);
        }
    }
}
