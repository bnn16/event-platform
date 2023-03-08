using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace event_platform.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public string Message { get; set; }

        public ConfirmEmailModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string token)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            //if user doens't exist give an error msg
            if (user != null)
            {
                //if correct user id == validate token
                var result = await this.userManager.ConfirmEmailAsync(user, token);                
                if (result.Succeeded)
                {
                    this.Message = "Email address is successfully confirm, now you can try to login.";
                    return Page();
                }
            }

            this.Message = "Failed to validate email.";
            return Page();
        }
    }
}
