using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.ViewModels;
using Repositories;
using Repositories.Implementations;

namespace RazorPages.Pages.CandidateProfileView
{
    public class IndexModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();
        [BindProperty] public string SearchValue { get; set; }

        public IList<CandidateProfile> CandidateProfile { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!AdminCheck())
            {
                return RedirectToPage("../Login/Login");
            }
            else {

                CandidateProfile = await CandidateProfileRepository.GetAllCandidate();
                return Page();
            }


        }

        public async Task<IActionResult> OnPostSearch()
        {

            if (!AdminCheck())
            {
                return RedirectToPage();
            }

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

        private bool AdminCheck()
        {
            var loginUser = HttpContext.Session.GetObjectFromJson<Hraccount>("user");
            if(loginUser == null || loginUser.MemberRole == 3)
            {
                return false;
            }

            return true;
        }
    }
}
