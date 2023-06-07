using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObjects.Models;

namespace RazorPages.Pages.AuthorInstitution2023DB
{
    public class EditModel : PageModel
    {
        private readonly BussinessObjects.Models.AuthorInstitution2023DBContext _context;

        public EditModel(BussinessObjects.Models.AuthorInstitution2023DBContext context)
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
           ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "Area");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CorrespondingAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrespondingAuthorExists(CorrespondingAuthor.AuthorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CorrespondingAuthorExists(string id)
        {
            return _context.CorrespondingAuthors.Any(e => e.AuthorId == id);
        }
    }
}
