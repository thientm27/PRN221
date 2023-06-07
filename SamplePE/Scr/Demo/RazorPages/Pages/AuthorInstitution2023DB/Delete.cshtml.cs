using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObjects.Models;

namespace RazorPages.Pages.AuthorInstitution2023DB
{
    public class DeleteModel : PageModel
    {
        private readonly BussinessObjects.Models.AuthorInstitution2023DBContext _context;

        public DeleteModel(BussinessObjects.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CorrespondingAuthor = await _context.CorrespondingAuthors.FindAsync(id);

            if (CorrespondingAuthor != null)
            {
                _context.CorrespondingAuthors.Remove(CorrespondingAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
