using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public interface ISliderRepository
    {
        public IEnumerable<Slider> GetAllSlider();
        public Slider GetSlider(int id);

    }
}
