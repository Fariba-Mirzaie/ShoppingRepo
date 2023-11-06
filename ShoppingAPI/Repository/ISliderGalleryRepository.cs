using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public interface ISliderGalleryRepository
    {
        public List<SliderGallery> GetGroups(int galleyId);
    }
}
