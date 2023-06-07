
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObjects.Models;

namespace RazorPages.Pages.AuthorInstitution2023DB
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObjects.Models.AuthorInstitution2023DBContext _context;

        public DetailsModel(BussinessObjects.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        public CorrespondingAuthor CorrespondingAuthor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CorrespondingAuthor = await _context.CorrespondingAuthors
                .Include(c => c.Institution).FirstOrDefaultAsync(m => m.AuthorId == id);

            if (CorrespondingAuthor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
