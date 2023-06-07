using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObjects.Models;

namespace RazorPages.Pages.AuthorInstitution2023DB
{
    public class CreateModel : PageModel
    {
        private readonly BussinessObjects.Models.AuthorInstitution2023DBContext _context;

        public CreateModel(BussinessObjects.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "Area");
            return Page();
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CorrespondingAuthors.Add(CorrespondingAuthor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
