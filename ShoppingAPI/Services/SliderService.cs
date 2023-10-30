using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Repository;
using ShoppingAPI.Functions.Sorting;

namespace ShoppingAPI.Services
{
    public class SliderService : ISliderRepository
    {
        private readonly MyContext _context;
        public SliderService(MyContext context) => _context = context;

        public IEnumerable<Slider> GetAllSlider(PaginationFilter pagination, SortingParams sorting, FilterParams filtering)
        {
            var slidersData = _context.Sliders.AsQueryable();
            var validFilter = new PaginationFilter(pagination.pageNumber, pagination.pageSize, slidersData.Count());

            if (!string.IsNullOrEmpty(filtering.Title))
                slidersData = slidersData.Where(s => s.Title.Contains(filtering.Title));


            if (sorting.Type == SortingParams.SortType.Asc)
                slidersData = slidersData.OrderBy(s => s.SliderId);
            else if (sorting.Type == SortingParams.SortType.Desc)
                slidersData = slidersData.OrderByDescending(s => s.SliderId);


            slidersData = slidersData.Skip((validFilter.pageNumber - 1) * validFilter.pageSize).Take(validFilter.pageSize);

            return slidersData.ToList();
        }

        public Slider GetSlider(int id)
        {
            throw new NotImplementedException();
        }
    }
}
