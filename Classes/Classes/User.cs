namespace event_platform_classLibrary.EventHandlers.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public string AuthToken { get; internal set; }

        public List<string> usersTags = new List<string>();
    }
}
