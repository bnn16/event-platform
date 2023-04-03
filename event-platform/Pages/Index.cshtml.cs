using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using event_platform_classLibrary.EventHandlers.UserStrategy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace event_platform.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DBController _dbController;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _dbController = new DBController();
        }

        public string Username { get; set; }
        public List<Event> Events { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowOnlyConcerts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

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

            var _userManager = new UserManager(new UserWebStrategy(_dbController));
            (List<Event> events, List<ConcertEvent> concerts) = _dbController.GetListOfEvents(); _userManager.GetEvents();

            Events = events.Where(e => !(e is ConcertEvent && !ShowOnlyConcerts)).ToList();

            //add only the concerts to the list
            if (ShowOnlyConcerts)
            {
                Events.AddRange(concerts);
            }

            //filter the events by title
            if (!string.IsNullOrEmpty(SearchTitle))
            {
                Events = Events.Where(e => e.Name.Contains(SearchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Page();
        }
    }
}
