using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Courses
{
    public class IndexModel : PageModel
    {
        private readonly CourseDbContext _db;
        public IEnumerable<CourseListViewModel> Courses { get; set; }
        public IndexModel(CourseDbContext db)
        {
            this._db = db;
        }
        public async Task OnGet()
        {
            Courses = await _db.Course.Include(u => u.AppUser).Include(c => c.Category)
                .Select(p => new CourseListViewModel
                {
                    CourseId = p.CourseId,  
                    Title=p.Title,
                    Description=p.Description,  
                    price= p.price,
                    PublishedDate=(p.PublishedDate==DateTime.MinValue ? null : p.PublishedDate.ToShortDateString()),
                    ImageUrl=p.ImageUrl,    
                    Category=p.Category.Name,   
                    Author=p.AppUser.FullName
                }).ToListAsync();
        }
    }
}
