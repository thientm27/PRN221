using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.ViewModels;
using Repositories;
using Repositories.Implementations;
using System.Threading.Tasks;

namespace RazorPages.Pages.Login
{
    public class LoginModel : PageModel
    {
        IHrAccountRepository hrAccountRepository = new HrAccountRepository();
        [BindProperty] public Hraccount User { get; set; }

        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerLogin = hrAccountRepository.Login(User.Email, User.Password);


            if (customerLogin == null)
            {
                ModelState.AddModelError(string.Empty, "You are not allowed to access this function!");
                return Page();
            }
            else
            {
                HttpContext.Session.SetObjectAsJson("user", customerLogin);
                return RedirectToPage("../CandidateProfileView/Index");
            }

        }

        public IActionResult OnPostLogOutAsync()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Login/Login");
        }
    }
}
