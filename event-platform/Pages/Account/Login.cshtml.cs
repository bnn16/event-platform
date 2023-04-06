using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace event_platform.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IDBController _dbController;

        [BindProperty]
        public LoginBindModel Input { get; set; }

        public LoginModel()
        {
            _dbController = new DBController();
        }

        public IActionResult OnGet()
        {
            //if there are cookies redirect to /index
            if (Request.Cookies["AuthToken"] != null || Request.Cookies["UserId"] != null)
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
            //verify the users credentials (can be a bit cleaner) todo: clean up code
            User user = null;
            user = _dbController.GetUserByUsernameOrEmail(Input);
            if (user == null || !BCrypt.Net.BCrypt.Verify(Input.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return Page();
            }
            if (user.Role != "User")
            {
                ModelState.AddModelError("", "You are not authorized to log in.");
                return Page();
            }

            if (Request.Cookies["AuthToken"] == null || Request.Cookies["UserId"] == null)
            {
                // delete any existing auth tokens associated with the user, and add a new auth token.
                _dbController.DeleteAuthToken(user.Id);

                var authToken = Guid.NewGuid().ToString();
                _dbController.InsertAuthToken(user.Id, authToken);

                // set the auth token and user ID cookies
                Response.Cookies.Append("AuthToken", authToken, new CookieOptions { HttpOnly = true });
                Response.Cookies.Append("UserId", user.Id.ToString(), new CookieOptions { HttpOnly = true });
            }

            return RedirectToPage("/Index");
        }
    }
}
