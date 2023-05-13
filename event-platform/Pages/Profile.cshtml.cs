using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager _userManager;

        public ProfileModel(IUserDBController dBController)
        {
            _userManager = new UserManager(dBController);
        }

        [BindProperty]
        public UserBindModel User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int userId;

            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = _userManager.GetAuthenticatedUser(userId);
            User = new UserBindModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Description = user.Description,
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            int userId;

            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = _userManager.GetAuthenticatedUser(userId);

            if (!string.IsNullOrEmpty(User.Username) && User.Username != user.Username)
            {
                user.Username = User.Username;
            }
            if (!string.IsNullOrEmpty(User.Email) && User.Email != user.Email)
            {
                user.Email = User.Email;
            }
            if (!string.IsNullOrEmpty(User.Description) && User.Description != user.Description)
            {
                user.Description = User.Description;
            }

            _userManager.UpdateUser(user);

            return RedirectToPage();
        }

    }
}
