using ShoppingAPI.Models;
using ShoppingAPI.BaseParameters;
using ShoppingAPI.DTO;

namespace ShoppingAPI.Repository
{
    public interface ISliderRepository
    {
        public IEnumerable<SliderDTO> GetAll(SliderParameters sliderParameters);
        public Slider Get(int id);
        public Slider Add(SliderDTO sliderDto);
    }
}
