using DAL;
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
        private readonly IDBController _dbController;
        private readonly IUserDBController userDbController;

        private readonly event_platform_classLibrary.UserManager _userManager;

        public IndexModel(ILogger<IndexModel> logger, IUserDBController user, IDBController events)
        {
            _logger = logger;
            userDbController = user;
            _dbController = events;
            _userManager = new event_platform_classLibrary.UserManager(userDbController);
        }

        public string Username { get; set; }
        public List<Event> Events { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowOnlyConcerts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        public IActionResult OnGet()
        {
            int userId;
            //check if there are no cookies, if true --> logout
            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            //if there are cookies, validate them with the db, if !false -> logout
            User user = _userManager.GetAuthenticatedUser(userId);
            Username = user.Username;
            ViewData["Email"] = user.Email;
            ViewData["Description"] = user.Description;


            var testManager = new event_platform_classLibrary.EventHandlers.UserStrategy.UserManager(new UserWebStrategy(_dbController));
            (List<Event> events, List<ConcertEvent> concerts) = _dbController.GetListOfEvents(); testManager.GetEvents();

            Events = events.Where(e => !(e is ConcertEvent && ShowOnlyConcerts)).ToList();

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
