using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Functions.Sorting;
using ShoppingAPI.DTO;

namespace ShoppingAPI.Repository
{
    public interface ISliderRepository
    {
        public IEnumerable<SliderDTO> GetAll(PaginationFilter pagination, SortingParams sorting, FilterParams filtering );
        public Slider Get(int id);
        public Slider Add(SliderDTO dtoSlider);

    }
}
