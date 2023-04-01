using event_platform_classLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private DBController _dbController;

        public LogoutModel(DBController dbController)
        {
            _dbController = dbController;
        }


        public void OnGet()
        {
            //when pressing logout delete all the cookies in the browser and delete the auth token todo: make it so multiple devices can be logged in at the same time
            if (HttpContext.Request.Cookies.TryGetValue("AuthToken", out string authToken))
            {
                int userId = int.Parse(HttpContext.Request.Cookies["UserId"]);
                _dbController.DeleteAuthToken(userId);

                HttpContext.Response.Cookies.Delete("AuthToken");
                HttpContext.Response.Cookies.Delete("UserId");
            }
            Response.Redirect("/Account/Login");
        }
    }
}
