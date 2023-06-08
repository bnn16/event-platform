using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using event_platform_classLibrary.Strategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDBController _dbController;
        private readonly IUserDBController userDbController;
        private EventRanker eventRanker;
        private readonly EventManager eventManager;

        private readonly AuthUserManager authUserManager;
        private readonly UserManager userManager;

        public IndexModel(ILogger<IndexModel> logger, IUserDBController user, IDBController events)
        {
            _logger = logger;
            userDbController = user;
            _dbController = events;
            authUserManager = new AuthUserManager(userDbController, events);
            eventRanker = new EventRanker(new TagFilterAlgo());
            eventManager = new EventManager(events);
            userManager = new UserManager(userDbController, events);
        }

        public string Username { get; set; }
        public List<Event> Events { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowOnlyConcerts { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool ShowOnlyPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }
        public List<User> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public float lowerBound { get; set; }
        [BindProperty(SupportsGet = true)]
        public float upperBound { get; set; }
        public IActionResult OnGet()
        {

            int userId;
            //check if there are no cookies, if true --> logout
            if (!authUserManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            //if there are cookies, validate them with the db, if !false -> logout
            User user = authUserManager.GetAuthenticatedUser(userId);
            Username = user.Username;
            ViewData["Email"] = user.Email;
            ViewData["Description"] = user.Description;

            List<(int eventId, string tag)> tags = eventManager.GetAllEventTags();
            List<string> userTags = eventManager.GetAllUserTags(userId);


            (List<Event> events, List<ConcertEvent> concerts) = userManager.GetEvents();

            Events = events.Where(e => !(e is ConcertEvent && ShowOnlyConcerts)).ToList();

            foreach (var e in tags)
            {
                for (int i = 0; i < Events.Count; i++)
                {

                    if (e.eventId == Events[i].Id)
                    {
                        Events[i].tags.Add(e.tag);
                    }
                }

            }

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

            Users = new List<User>
            {
                user
            };


            List<(User user, List<(Event, float)> eventRatios)> userEventRatios = eventRanker.RankAndPrintEvents(Users, Events);

            eventRanker = new EventRanker(new PriceFilterAlgo(0, 0));


            List<(User user, List<(Event, float)> eventRatios)> priceRatios = eventRanker.RankAndPrintEvents(Users, Events);

            ViewData["PriceRatios"] = priceRatios;

            eventRanker = new EventRanker(new PriceFilterAlgo(lowerBound, upperBound));

            priceRatios = eventRanker.RankAndPrintEvents(Users, Events);


            ViewData["UserEventRatios"] = userEventRatios;

            if (ShowOnlyPrice)
            {
                List<Event> temp = new List<Event>();
                for (int i = 0; i < Events.Count; i++)
                {
                    if (Events[i].Price > 0)
                    {
                        temp.Add(Events[i]);

                    }
                    else
                    {
                        continue;
                    }
                }
                Events = temp;
            }


            if (lowerBound > 0 && upperBound > 0)
            {
                List<Event> priceEvents = priceRatios.SelectMany(pr => pr.eventRatios.Select(er => er.Item1)).ToList();

                Events = priceEvents;
            }

            return Page();
        }
    }
}
