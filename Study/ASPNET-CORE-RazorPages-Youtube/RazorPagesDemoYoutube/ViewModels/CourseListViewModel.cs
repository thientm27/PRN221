using RazorPagesDemoYoutube.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDemoYoutube.ViewModels
{
    public class CourseListViewModel
    {
        public Guid? CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double price { get; set; }

        [Display(Name = "Published Date")]
        public string PublishedDate { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }
    }
}
