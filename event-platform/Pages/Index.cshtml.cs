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

        public IndexModel(ILogger<IndexModel> logger)
	{
		_logger = logger;
	}

	public void OnGet()
	{
            Events = new List<Event>
        {
            new Event { Id = 1, Title = "Event 1", ImageUrl = "https://images.pexels.com/photos/2747449/pexels-photo-2747449.jpeg?cs=srgb&dl=pexels-wolfgang-2747449.jpg&fm=jpg", Description = "Event 1 description" },
            new Event { Id = 2, Title = "Event 2", ImageUrl = "https://events.enderuncolleges.com/wp-content/uploads/2019/03/atrium.jpg", Description = "Event 2 description" },
          
        };

        }
}
}