using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Users
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IToastNotification _notify;
        private readonly IMapper _mapper;

        [BindProperty]
        public UserInputVeiwModel UserInput { get; set; }
        public RegisterModel(UserManager<AppUser> userManager, IToastNotification notify, IMapper mapper)
        {
            this._userManager = userManager;
            this._notify = notify;
            this._mapper = mapper;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                AppUser user = _mapper.Map<AppUser>(UserInput);
                user.UserName = UserInput.Email;
                var res = await _userManager.CreateAsync(user,UserInput.Password);
                if (res.Succeeded)
                {
                    _notify.AddSuccessToastMessage("User created successfully ");
                    return RedirectToPage("Index");
                }
                else
                {
                    _notify.AddErrorToastMessage("User not created successfully ");
                    return Page();
                }
            }
            return Page();
        }
    }
}
