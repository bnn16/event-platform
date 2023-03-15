using ClassesEvent_Platform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace event_platform.Pages
{
[Authorize]
public class IndexModel : PageModel
{
	private readonly ILogger<IndexModel> _logger;
        public List<Event> Events { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool ShowOnlyWeddings { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
	{
		_logger = logger;
	}

        public void OnGet()
        {
            Events = new List<Event>
        {
              new Event { Id = 1, Title = "Party!!", ImageUrl = "https://images.pexels.com/photos/2747449/pexels-photo-2747449.jpeg?cs=srgb&dl=pexels-wolfgang-2747449.jpg&fm=jpg", Description = "don't be a buzzkill" },
            new Event { Id = 2, Title = "Party karra karra", ImageUrl = "https://events.enderuncolleges.com/wp-content/uploads/2019/03/atrium.jpg", Description = "Come and join us in the paaaaaartayyyyyy" },
             new Wedding { Id = 3, Title = "Alice and Bob", ImageUrl = "https://www.visitdubai.com/-/media/gathercontent/article/u/unique-wedding-settings-in-dubai/media/unique-wedding-venues-in-dubai-9.jpg", Description = "A beautiful wedding celebration", NumberOfGuests = 100, WeddingDate = DateTime.Now.AddMonths(2), Venue = "The Grand Ballroom" }
        };
            if (ShowOnlyWeddings)
            {
                Events = Events.Where(e => e is Wedding).ToList();
            }
            if (!string.IsNullOrWhiteSpace(SearchTitle))
            {
                Events = Events.Where(e => e.Title.Contains(SearchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
            }

        }

        }
}
