using event_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager) 
        { 
            this.signInManager = signInManager;
        }
        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) return Page();

           var res = await signInManager.PasswordSignInAsync
                (
                this.LoginViewModel.Email, 
                this.LoginViewModel.Password, 
                this.LoginViewModel.RememberMe,
                false);
            if (res.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else 
            {
                //if the user cant loign for 10 attempts 5 min lockout.
                if (res.IsLockedOut) {
                    ModelState.AddModelError("Login", "Locked out, try again later");
                }
                //make user stay on the same page
                return Page();
            }
            
        }
    }
}
