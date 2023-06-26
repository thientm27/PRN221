using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.Implementations;
using Repositories;
using RazorPage.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace RazorPages.Pages.CandidateProfileView
{
    public class DeleteModel : PageModel
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

            CandidateProfile = await CandidateProfileRepository.FindCandidate(id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!AdminCheck())
            {
                return RedirectToPage("../Login/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            await CandidateProfileRepository.DeleteCandidate(id);
            var _hubContext = (IHubContext<SignalrHubServer>)HttpContext.RequestServices.GetService(typeof(IHubContext<SignalrHubServer>));
            await Task.Delay(1500);
            await _hubContext.Clients.All.SendAsync("LoadCustomer");
            return RedirectToPage("./Index");
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
