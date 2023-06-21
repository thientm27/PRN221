using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RazorPagesDemoYoutube.ViewModels
{
    public class CategoryViewModel
    {
        public Guid? CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 30 Caracters")]
        public string Name { get; set; } = String.Empty;

        [Display(Name = "Order Dispaly")]
        [Required(ErrorMessage = "Order Dispaly is required")]
        [Range(0, 50, ErrorMessage = "Order Dispaly must be between 1 and 50")]
        public int OrderDispay { get; set; }
    }
}
