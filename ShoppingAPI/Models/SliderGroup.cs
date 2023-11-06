using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{
    public class SliderGroup
    {
        public int SliderGroupId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<Slider> Sliders { get; set; }
        public ICollection<SliderGallery> Gallery { get; set; }

    }
}
