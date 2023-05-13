using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.EventStrategy.EventStrategy;
using event_platform_classLibrary.EventHandlers.UserStrategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace event_platform.Pages
{
    public class BookEventModel : PageModel
    {
        private readonly IDBController _dbController;

        public BookEventModel(DBController dbController)
        {
            _dbController = dbController;
        }

        public Event Event { get; set; }

        public IActionResult OnGet(int id)
        {
            if (Request.Cookies["AuthToken"] == null || Request.Cookies["UserId"] == null)
            {
                return RedirectToPage("/Account/Login");
            }

            int userId = int.Parse(Request.Cookies["UserId"]);
            string authToken = Request.Cookies["AuthToken"];
            if (!_dbController.IsAuthTokenValid(userId, authToken))
            {
                return RedirectToPage("/Account/Login");
            }

            Event = _dbController.GetEventByIdObj(id);
            if (Event == null)
            {
                return NotFound();
            }
            bool result = _dbController.AddBooking(Event.Id, userId);


            return Page();
        }
    }
}
