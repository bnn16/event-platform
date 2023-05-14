using System.ComponentModel.DataAnnotations;

namespace event_platform_classLibrary
{    
    public class UserBindModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<string> usersTags = new List<string>();
    }
}
