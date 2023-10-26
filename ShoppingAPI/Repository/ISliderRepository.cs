using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Functions.Sorting;

namespace ShoppingAPI.Repository
{
    public interface ISliderRepository
    {
        public IEnumerable<Slider> GetAllSlider(PaginationFilter pagination, SortingParams sorting, FilterParams filtering);
        public Slider GetSlider(int id);

    }
}
