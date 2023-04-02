using event_platform_classLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class ProfileModel : PageModel
    {
        public UserBindModel User { get; set; }
        private readonly DBController _dbController;

        public ProfileModel(DBController dbController)
        {
            _dbController = dbController;
        }

        public string Username { get; set; }
        public string id { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            //todo: make it cleaner
            int userId = int.Parse(Request.Cookies["UserId"]);
            string authToken = Request.Cookies["AuthToken"];
            if (!_dbController.IsAuthTokenValid(userId, authToken))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = _dbController.GetUserById(userId);
            Username = user.Username;
            User = new UserBindModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Description = user.Description,
            };
            return Page();
        }
    }
}
