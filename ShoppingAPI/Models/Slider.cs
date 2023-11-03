using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models
{
    [Table("TopSliders")]
    public class Slider
    {
        public int SliderId { get; set; }
        [MaxLength(50,ErrorMessage ="تعداد کاراکتر مجاز 50 می باشد.")]
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; } = true;
        [MaxLength(200,ErrorMessage ="تعداد کاراکترهای مجاز 200 کاراکتر می باشد")]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
