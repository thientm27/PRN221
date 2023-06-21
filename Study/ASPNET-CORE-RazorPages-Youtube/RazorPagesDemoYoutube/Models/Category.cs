using System.ComponentModel.DataAnnotations;

namespace RazorPagesDemoYoutube.Models
{
    public class Category
    {
        [Key]
        public Guid? CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [StringLength(maximumLength:30,MinimumLength =3,ErrorMessage = "Category Name must be between 3 and 30 Caracters")]
        public string Name { get; set; } = String.Empty;

        [Display(Name = "Order Dispaly")]
        [Range(0,50,ErrorMessage = "Price must be between 1 and 50")]
        public int OrderDispay { get; set; }
    }
}
