using event_platform_classLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private DBController _dbController;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _dbController = new DBController();
        }

        public string Username { get; set; }

        public IActionResult OnGet()
        {
            //check if there are no cookies, if true --> logout
            if (Request.Cookies["AuthToken"] == null || Request.Cookies["UserId"] == null)
            {
                return RedirectToPage("/Account/Login");
            }

            //if there are cookies, validate them with the db, if !false -> logout
            int userId = int.Parse(Request.Cookies["UserId"]);
            string authToken = Request.Cookies["AuthToken"];
            if (!_dbController.IsAuthTokenValid(userId, authToken))
            {
                return RedirectToPage("/Account/Login");
            }

            //populate the page.
            User user = _dbController.GetUserById(userId);
            Username = user.Username;
            ViewData["Email"] = user.Email;
            ViewData["Description"] = user.Description;

            return Page();
        }
    }
}