
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.Implementations;
using Repositories;
using RazorPage.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace RazorPages.Pages.CandidateProfileView
{
    public class EditModel : PageModel
    {
        ICandidateProfileRepository CandidateProfileRepository = new CandidateProfileRepository();


        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!AdminCheck())
            {
                return RedirectToPage("../Login/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await CandidateProfileRepository.FindCandidate(id) ;
            if (CandidateProfile == null)
            {
                return NotFound();
            }
           ViewData["PostingId"] = new SelectList(await CandidateProfileRepository.GetAllJobs(), "PostingId", "PostingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!AdminCheck())
            {
                return RedirectToPage();
            }
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

            try
            {
                await  CandidateProfileRepository.UpdateCandidate(CandidateProfile);
                var _hubContext = (IHubContext<SignalrHubServer>)HttpContext.RequestServices.GetService(typeof(IHubContext<SignalrHubServer>));
                await Task.Delay(1500);
                await _hubContext.Clients.All.SendAsync("LoadCustomer");
            }
            catch (DbUpdateConcurrencyException)
            {
    
                    throw;
                
            }

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
            if (CandidateProfile.ProfileShortDescription.Length <= 11 || CandidateProfile.ProfileShortDescription.Length >= 201)
            {
                ModelState.AddModelError(string.Empty, "ProfileDescription from 12 – 200 characters.");
                return false;
            }

            // Name
            if (CandidateProfile.Fullname.Length <= 11)
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
