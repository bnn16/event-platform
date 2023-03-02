using event_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        public RegisterModel(UserManager<IdentityUser> userManager) { 
            this.userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new IdentityUser 
            { 
                Email = RegisterViewModel.Email, 
                UserName = RegisterViewModel.Email 
            };

            //attempts to create the user if false ==> throw error, if successful login!
            var res = await this.userManager.CreateAsync(user, RegisterViewModel.Password);
            if (res.Succeeded)
            {
                return RedirectToPage("/Acount/Login");
            }
            else
            {
                foreach (var error in res.Errors)
                { 
                    ModelState.AddModelError("Register", error.Description);
                }
                return Page();
            }
        }
    }
}
