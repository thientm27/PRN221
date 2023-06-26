using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPages.Pages.CandidateProfileView
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.Models.CandidateManagementContext _context;

        public EditModel(BusinessObject.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await _context.CandidateProfiles
                .Include(c => c.Posting).FirstOrDefaultAsync(m => m.CandidateId == id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
           ViewData["PostingId"] = new SelectList(_context.JobPostings, "PostingId", "PostingId");
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

            _context.Attach(CandidateProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
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

        private bool CandidateProfileExists(string id)
        {
            return _context.CandidateProfiles.Any(e => e.CandidateId == id);
        }
    }
}
