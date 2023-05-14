using DAL;
using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager _userManager;
        public Dictionary<int, string> EventTags { get; set; }
        [BindProperty]
        public List<int> SelectedTags { get; set; }



        public ProfileModel(IUserDBController dBController)
        {
            _userManager = new UserManager(dBController);
            SelectedTags = new List<int>();
        }

        [BindProperty]
        public UserBindModel User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int userId;

            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = _userManager.GetAuthenticatedUser(userId);
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

            SelectedTags = user.usersTags.Select(int.Parse).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            int userId;

            if (!_userManager.IsAuthenticated(Request.Cookies, out userId))
            {
                return RedirectToPage("/Account/Login");
            }

            User user = _userManager.GetAuthenticatedUser(userId);

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

            _userManager.UpdateUser(user);

            user.usersTags.Clear();
            foreach (var tagId in SelectedTags)
            {
                user.usersTags.Add(tagId.ToString());
            }

            _userManager.SaveUserTags(user);

            return RedirectToPage();
        }

    }
}
