using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDemoYoutube.Models
{
    public class Course
    {
        [Key]
        public Guid? CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public AppUser AppUser { get; set; }

    }
}
