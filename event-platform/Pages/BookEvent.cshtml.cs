using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class BookEventModel : PageModel
    {
        private readonly IDBController _dbController;
        private readonly AuthUserManager authUserManager;
        private readonly EventManager _eventManager;
        private readonly UserManager userManager;

        public string Message { get; set; }

        public BookEventModel(IDBController dbController, IUserDBController userController)
        {
            _dbController = dbController;
            authUserManager = new AuthUserManager(userController, dbController);
            _eventManager = new EventManager(_dbController);
            userManager = new UserManager(userController, dbController);
        }

        public Event Event { get; set; }

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
            string code = _eventManager.GenerateRandomCode();
            bool result = userManager.BookEvent(Event.Id, userId, code);

            if (result)
            {
                Message = "You have successfully booked the event. Your code for the event is - " + code;
            }
            else
            {
                Message = "You have already booked the event.";
            }
            return Page();
        }
    }
}
