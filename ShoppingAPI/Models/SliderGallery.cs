using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{
    public class SliderGallery
    {
        public int SliderGalleryId { get; set; }
        [MaxLength(50 , ErrorMessage ="حداکثر تعداد کاراکتر مجاز 50 می باشد.")]
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public ICollection<SliderGroup> Groups { get; set; }    

    }
}
