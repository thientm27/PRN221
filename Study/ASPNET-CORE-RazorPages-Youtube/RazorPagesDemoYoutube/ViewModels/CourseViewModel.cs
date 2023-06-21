using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RazorPagesDemoYoutube.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDemoYoutube.ViewModels
{
    public class CourseViewModel
    {
        public Guid? CourseId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double price { get; set; }
                
        public DateTime? PublishedDate { get; set; }

        [Display(Name = "Course Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Category ")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Author")]
        public string AuthorId { get; set; }

    }
}
