using System;
using System.Collections.Generic;
using System.Linq;
using ClassesEvent_Platform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class BookEventModel : PageModel
    {
        public int Id { get; set; }

        public IActionResult OnGet(int id)
        {
            Id = id;
            var eventInfo = GetEventById(id);

            if (eventInfo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public Event GetEventById(int id)
        {
            // Retrieve the event by ID from your List<Event> or data source
            // Replace the following example with your actual data retrieval logic
            var events = new List<Event>
            {
                 new Event { Id = 1, Title = "Event 1", ImageUrl = "https://images.pexels.com/photos/2747449/pexels-photo-2747449.jpeg?cs=srgb&dl=pexels-wolfgang-2747449.jpg&fm=jpg", Description = "Event 1 description" },
            new Event { Id = 2, Title = "Event 2", ImageUrl = "https://events.enderuncolleges.com/wp-content/uploads/2019/03/atrium.jpg", Description = "Event 2 description" },
             new Wedding { Id = 3, Title = "Alice and Bob", ImageUrl = "https://www.visitdubai.com/-/media/gathercontent/article/u/unique-wedding-settings-in-dubai/media/unique-wedding-venues-in-dubai-9.jpg", Description = "A beautiful wedding celebration", NumberOfGuests = 100, WeddingDate = DateTime.Now.AddMonths(2), Venue = "The Grand Ballroom" }
            };

            return events.FirstOrDefault(e => e.Id == id);
        }
    }
}
