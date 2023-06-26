using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Repositories.Implementations;
using Repositories;
using System.Linq;
using System;

namespace RazorPages.Pages.CandidateProfileView
{
    public class CreateModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["PostingId"] = new SelectList(await CandidateProfileRepository.GetAllJobs(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PostingId"] = new SelectList(await CandidateProfileRepository.GetAllJobs(), "PostingId", "JobPostingTitle");
                return Page();
            }
            if (!Validation())
            {
                ViewData["PostingId"] = new SelectList(await CandidateProfileRepository.GetAllJobs(), "PostingId", "JobPostingTitle");
                return Page();
            }

            await CandidateProfileRepository.CreateNew(CandidateProfile);

            return RedirectToPage("./Index");
        }

        private bool Validation()
        {
            if (string.IsNullOrEmpty(CandidateProfile.Fullname))
            {
                ModelState.AddModelError(string.Empty, "All fields are required.");
                return false;
            }
            if (string.IsNullOrEmpty(CandidateProfile.ProfileUrl))
            {
                ModelState.AddModelError(string.Empty, "All fields are required.");
                return false;
            }
            if ((CandidateProfile.Birthday == null))
            {
                ModelState.AddModelError(string.Empty, "All fields are required.");
                return false;
            }
            if (string.IsNullOrEmpty(CandidateProfile.ProfileShortDescription))
            {
                ModelState.AddModelError(string.Empty, "All fields are required.");
                return false;
            }
            if (CandidateProfile.ProfileShortDescription.Length <= 12 || CandidateProfile.ProfileShortDescription.Length >= 201)
            {
                ModelState.AddModelError(string.Empty, "ProfileDescription from 12 – 200 characters.");
                return false;
            }

            // Name
            if (CandidateProfile.Fullname.Length <= 12)
            {
                ModelState.AddModelError(string.Empty, "Full name must be greater than 12 characters.");

                 return false;
            }

            string[] nameParts = CandidateProfile.Fullname.Split(' ');

            if (nameParts.Any(part => !char.IsUpper(part[0])))
            {
                ModelState.AddModelError(string.Empty, "Each word of the full name must begin with a capital letter.");
                 return false;
            }

            return true;
        }
    }
}
