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
            var validFilter = new PaginationFilter(pagination.pageNumber, pagination.pageSize);
            var pagedData = _context.Sliders.AsQueryable();
               
            if (!string.IsNullOrEmpty(filtering.Title))
                pagedData = pagedData.Where(s => s.Tilte.Contains(filtering.Title));


            if (sorting.Type == 0)
                pagedData = pagedData.OrderBy(s => s.SliderId);
            else
                pagedData = pagedData.OrderByDescending(s => s.SliderId);

            pagedData= pagedData.Skip((validFilter.pageNumber - 1) * validFilter.pageSize)
               .Take(validFilter.pageSize);


            return pagedData.ToList();
        }

        public Slider GetSlider(int id)
        {
            throw new NotImplementedException();
        }
    }
}
