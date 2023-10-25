using ShoppingAPI.Models;
using ShoppingAPI.Repository;

namespace ShoppingAPI.Services
{
    public class SliderService : ISliderRepository
    {
        private readonly MyContext _context;
        public SliderService(MyContext context) => _context = context;

        public IEnumerable<Slider> GetAllSlider()
        {
            return _context.Sliders.ToList();
        }

        public Slider GetSlider(int id)
        {
            throw new NotImplementedException();
        }
    }
}
