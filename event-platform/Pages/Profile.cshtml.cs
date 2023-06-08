using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly AuthUserManager authUserManager;
        private readonly UserManager userManager;
        public Dictionary<int, string> EventTags { get; set; }
        [BindProperty]
        public List<int> SelectedTags { get; set; }
        public List<Event> Events { get; set; }

        public Dictionary<int, string> BookingCodes { get; set; }


        public ProfileModel(IUserDBController dBController, IDBController eventController)
        {
            authUserManager = new AuthUserManager(dBController, eventController);
            SelectedTags = new List<int>();
            BookingCodes = new Dictionary<int, string>();
            userManager = new UserManager(dBController, eventController);
        }

        [BindProperty]
        public UserBindModel User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int userId;

            if (!authUserManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = authUserManager.GetAuthenticatedUser(userId);
            User = new UserBindModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Description = user.Description,
                usersTags = user.usersTags,
            };

            EventTags = new Dictionary<int, string>
            {
            {0, "No Tags" },
            { 1, "Art" },
        { 2, "Business" },
        { 3, "Celebrity" },
        { 4, "Charity" },
        { 5, "Concert" },
        { 6, "Conference" },
        { 7, "Cultural" },
        { 8, "Entertainment" },
        { 9, "Fashion" },
        { 10, "Festival" },
        { 11, "Film" },
        { 12, "Food" },
        { 13, "Music" },
        { 14, "Networking" },
        { 15, "Performing Arts" },
        { 16, "Sports" },
        { 17, "Technology" },
        { 18, "Theater" },
        { 19, "Travel" },
        { 20, "Comedy" }
    };

            (List<Event> events, List<ConcertEvent> concerts) = userManager.GetEventsUser(User.Id);

            Events = events;
            Events.AddRange(concerts);

            foreach (var ev in Events)
            {

                string bookingCode = userManager.GetBookingCodeForUserEvent(userId, ev.Id);
                BookingCodes[ev.Id] = bookingCode; // Store booking code in dictionary


            }

            SelectedTags = user.usersTags.Select(int.Parse).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            int userId;

            if (!authUserManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = authUserManager.GetAuthenticatedUser(userId);

            if (!string.IsNullOrEmpty(User.Username) && User.Username != user.Username)
            {
                user.Username = User.Username;
            }
            if (!string.IsNullOrEmpty(User.Email) && User.Email != user.Email)
            {
                user.Email = User.Email;
            }
            if (!string.IsNullOrEmpty(User.Description) && User.Description != user.Description)
            {
                user.Description = User.Description;
            }

            authUserManager.UpdateUser(user);

            user.usersTags.Clear();
            foreach (var tagId in SelectedTags)
            {
                user.usersTags.Add(tagId.ToString());
            }

            authUserManager.SaveUserTags(user);

            return RedirectToPage();
        }

    }
}
