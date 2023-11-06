using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public interface ISliderGalleryService
    {
        public List<SliderGallery> GetGroups(int galleyId);

    }
}
