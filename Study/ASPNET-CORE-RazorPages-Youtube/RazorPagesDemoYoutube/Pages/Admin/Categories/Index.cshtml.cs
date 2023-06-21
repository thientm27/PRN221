using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Models;

namespace RazorPagesDemoYoutube.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CourseDbContext _db;
        public IEnumerable<Category> CategoryList { get; set; }

        public IndexModel(CourseDbContext db)
        {
            this._db = db;
        }
        public async Task OnGet()
        {
            CategoryList = await _db.Category.OrderBy(c=>c.OrderDispay).ToListAsync();
        }
    }
}
