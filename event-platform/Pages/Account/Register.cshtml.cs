
using DAL;

using event_platform_classLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserDBController _dbcontroller;
        private readonly UserManager userManager;
        [BindProperty]
        public RegisterBindModel Input { get; set; }

        public RegisterModel(IUserDBController dbController)
        {
            _dbcontroller = dbController;
            userManager = new UserManager(_dbcontroller);
        }

        public IActionResult OnGet()
        {
            //if a person is logged in don't let them go to the register page.
            if (Request.Cookies["AuthToken"] != null || Request.Cookies["UserId"] != null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (userManager.GetUserByUsernameOrEmail(Input.Username) != null || userManager.GetUserByUsernameOrEmail(Input.Email) != null)
            {
                ModelState.AddModelError("", "Username or email already taken.");
                return Page();
            }

            bool success = await userManager.RegisterUserAsync(Input);
            if (success)
            {
                return RedirectToPage("/Account/Login");
            }

            ModelState.AddModelError("", "Error creating user account. Please try again.");
            return Page();
        }
    }
}
