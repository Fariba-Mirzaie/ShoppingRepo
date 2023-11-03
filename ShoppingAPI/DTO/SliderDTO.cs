using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.DTO
{
    public class SliderDTO
    {
        public int SliderId { get; set; }
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر مجاز 50 می باشد.")]
        public string Title { get; set; }
        public bool Status { get; set; } = true;
        public string MainImage { get; set; }
    }
}
