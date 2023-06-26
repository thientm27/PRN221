using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Implementations;

namespace RazorPages.Pages.CandidateProfileView
{
    public class IndexModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();

 
        public IList<CandidateProfile> CandidateProfile { get;set; }

        public async Task OnGetAsync()
        {
            CandidateProfile = await CandidateProfileRepository.GetAllCandidate();
        }
    }
}
