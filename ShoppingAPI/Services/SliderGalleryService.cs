using ShoppingAPI.Models;
using ShoppingAPI.Repository;

namespace ShoppingAPI.Services
{
    public class SliderGalleryService : ISliderGalleryService
    {
        private readonly ISliderGalleryRepository _sliderGalleryRepository;
        public SliderGalleryService(ISliderGalleryRepository sliderGallery) => _sliderGalleryRepository = sliderGallery;

        public List<SliderGallery> GetGroups(int galleyId)
        {
            var galleryList= _sliderGalleryRepository.GetGroups(galleyId);
            return galleryList;
        }
    }
}
