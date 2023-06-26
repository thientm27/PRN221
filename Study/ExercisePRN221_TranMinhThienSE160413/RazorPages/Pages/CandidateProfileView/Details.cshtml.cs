using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using RazorPage.ViewModels;
using Repositories.Implementations;
using Repositories;

namespace RazorPages.Pages.CandidateProfileView
{
    public class DetailsModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();
        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!AdminCheck())
            {
                return RedirectToPage();
            }
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await CandidateProfileRepository.FindCandidate(id);
            if (CandidateProfile == null)
            {
                return NotFound();
            }
            return Page();
        }
        private bool AdminCheck()
        {
            var loginUser = HttpContext.Session.GetObjectFromJson<Hraccount>("user");
            if (loginUser == null || loginUser.MemberRole == 3)
            {
                return false;
            }

            return true;
        }
    }
}
