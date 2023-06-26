using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace RazorPages.Pages.CandidateProfileView
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.CandidateManagementContext _context;

        public IndexModel(BusinessObject.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; }

        public async Task OnGetAsync()
        {
            CandidateProfile = await _context.CandidateProfiles
                .Include(c => c.Posting).ToListAsync();
        }
    }
}
