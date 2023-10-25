using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        [MaxLength(50,ErrorMessage ="تعداد کاراکتر مجاز 50 می باشد.")]
        public string Tilte { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; } = true;
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
