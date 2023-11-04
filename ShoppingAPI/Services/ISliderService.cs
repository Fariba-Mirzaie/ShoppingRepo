using ShoppingAPI.Models;
using ShoppingAPI.BaseParameters;
using ShoppingAPI.DTO;

namespace ShoppingAPI.Services
{
    public interface ISliderService
    {
        public IEnumerable<SliderDTO> GetAll(SliderParameters sliderParameters);
        public Slider Get(int id);
        public Slider Add(SliderDTO dtoSlider);
    }
}
