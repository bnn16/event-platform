using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserDBController _dbController;
        private readonly IDBController eventController;
        private AuthUserManager _userManager;

        [BindProperty]
        public LoginBindModel Input { get; set; }

        public LoginModel(IUserDBController dbController, IDBController eventController)
        {
            _dbController = dbController;
            eventController = eventController;
            _userManager = new AuthUserManager(_dbController, eventController);

        }

        public IActionResult OnGet()
        {
            //if there are cookies redirect to /index
            if (_userManager.IsAuthenticated(Request.Cookies, out _))
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Attempt to authenticate the user
            if (!_userManager.AuthenticateUser(Input, out User user))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return Page();
            }

            if (!_userManager.IsAuthorized(user))
            {
                ModelState.AddModelError("", "You are not authorized to log in.");
                return Page();
            }

            // Set the authentication token and user ID cookies
            _userManager.SetAuthCookies(Response.Cookies, user);

            return RedirectToPage("/Index");
        }
    }
}