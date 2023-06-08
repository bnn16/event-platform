using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class UnBookEventModel : PageModel
    {
        private readonly IDBController _dbController;
        private readonly AuthUserManager authUserManager;
        private readonly EventManager _eventManager;
        private readonly UserManager userManager;

        public string Message { get; set; }
        public Event Event { get; set; }

        public UnBookEventModel(IDBController dbController, IUserDBController userController)
        {
            _dbController = dbController;
            authUserManager = new AuthUserManager(userController, dbController);
            _eventManager = new EventManager(_dbController);
            userManager = new UserManager(userController, dbController);
        }

        public IActionResult OnGet(int id)
        {
            int userId;
            //check if there are no cookies, if true --> logout
            if (!authUserManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            //if there are cookies, validate them with the db, if !false -> logout
            User user = authUserManager.GetAuthenticatedUser(userId);

            Event = _eventManager.GetEventObj(id);
            if (Event == null)
            {
                return NotFound();
            }

            bool result = userManager.UnBookevent(Event.Id, userId);

            if (result)
            {
                Message = "You have successfully unbooked the event.";
            }
            else
            {
                Message = "Something went wrong...";
            }
            return Page();




            return Page();
        }
    }
}
