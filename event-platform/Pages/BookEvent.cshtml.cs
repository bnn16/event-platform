using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using event_platform_classLibrary;
using DAL;
using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform.Pages
{
    public class BookEventModel : PageModel
    {
        private readonly IDBController _dbController;
        private readonly UserManager _userManager;
        private readonly EventManager _eventManager;

        public string Message { get; set; }

        public BookEventModel(IDBController dbController, IUserDBController userController)
        {
            _dbController = dbController;
            _userManager = new UserManager(userController,dbController);
            _eventManager = new EventManager(_dbController);
        }

        public Event Event { get; set; }

        public IActionResult OnGet(int id)
        {
            int userId;
            //check if there are no cookies, if true --> logout
            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            //if there are cookies, validate them with the db, if !false -> logout
            User user = _userManager.GetAuthenticatedUser(userId);

            Event = _eventManager.GetEventObj(id);
            if (Event == null)
            {
                return NotFound();
            }
            string code = _eventManager.GenerateRandomCode();
            bool result = _userManager.BookEvent(Event.Id, userId, code);

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
