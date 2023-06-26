using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPages.Pages.CandidateProfileView
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.Models.CandidateManagementContext _context;

        public DeleteModel(BusinessObject.Models.CandidateManagementContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await _context.CandidateProfiles.FindAsync(id);

            if (CandidateProfile != null)
            {
                _context.CandidateProfiles.Remove(CandidateProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
