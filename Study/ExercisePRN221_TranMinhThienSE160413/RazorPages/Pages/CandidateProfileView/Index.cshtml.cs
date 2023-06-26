using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Implementations;

namespace RazorPages.Pages.CandidateProfileView
{
    public class IndexModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();
        [BindProperty] public string SearchValue { get; set; }

        public IList<CandidateProfile> CandidateProfile { get;set; }

        public async Task OnGetAsync()
        {
            CandidateProfile = await CandidateProfileRepository.GetAllCandidate();
        }

        public async Task<IActionResult> OnPostSearch()
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                CandidateProfile = await CandidateProfileRepository.GetAllCandidate();
            }
            else
            {
                CandidateProfile = await CandidateProfileRepository.SearchCandidate(SearchValue);

            }
            return Page();
        }
    }
}
