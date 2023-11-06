using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public class SliderGalleryRepository : ISliderGalleryRepository
    {
        private readonly MyContext _context;
        public SliderGalleryRepository(MyContext myContext) 
        { _context = myContext; 
        } 
   

        public List<SliderGallery> GetGroups(int galleyId)
        {
            var groups= _context.SliderGallerys.Where(g=>g.SliderGalleryId == galleyId).Include(s=>s.Groups).ToList();

            return groups;
            
        }
    }
}
