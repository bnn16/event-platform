using event_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;

namespace event_platform.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailService emailService;
        public RegisterModel(UserManager<IdentityUser> userManager, IEmailService emailService) { 
            this.userManager = userManager;
            this.emailService = emailService; ;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new IdentityUser 
            { 
                Email = RegisterViewModel.Email, 
                UserName = RegisterViewModel.Email 
            };

            //attempts to create the user if false ==> throw error, if successful login!
            var res = await this.userManager.CreateAsync(user, RegisterViewModel.Password);
            if (res.Succeeded)
            {
                var conToken = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                var conLink = Url.PageLink(pageName: "/Account/ConfirmEmail", values: new { userID = user.Id, token = conToken });

                await emailService.SendAsync("b.nikolov@student.fontys.nl", user.Email, "Confirm your email address", $"Please click on this link to confirm the mail: {conLink}");

                return RedirectToPage("/Account/Login");
            }
            else
            {
                foreach (var error in res.Errors)
                { 
                    ModelState.AddModelError("Register", error.Description);
                }
                return Page();
            }
        }
    }
}
