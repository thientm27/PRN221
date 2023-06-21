using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Users
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;

        [BindProperty]
        public LoginvViewModel InputLogin { get; set; }
        public LoginModel(SignInManager<AppUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(InputLogin.Email, InputLogin.Password
                    , InputLogin.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid login or password !!!");
                    return Page();
                }
            }
            return Page();

        }

        public  async Task<IActionResult> OnGetLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Admin/Users/Login");
        }
    }
}
