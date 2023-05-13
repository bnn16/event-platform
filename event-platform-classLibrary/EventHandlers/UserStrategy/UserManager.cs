using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers.UserStrategy
{
    public class UserManager
    {
        private readonly IUserWebStrategy _userWebStrategy;

        public UserManager(IUserWebStrategy userWebStrategy)
        {
            _userWebStrategy = userWebStrategy;
        }

        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            return _userWebStrategy.GetUserByUsernameOrEmail(usernameOrEmail);
        }

        public async Task<bool> RegisterUserAsync(RegisterBindModel input)
        {
            return await _userWebStrategy.RegisterUserAsync(input);
        }

        public async void InsertAuthToken(int userId, string token)
        {
            _userWebStrategy.InsertAuthToken(userId, token);
        }

        public void DeleteAuthToken(int userId)
        {
            _userWebStrategy.DeleteAuthToken(userId);
        }

        public bool IsAuthTokenValid(int userId, string authToken)
        {
            return _userWebStrategy.IsAuthTokenValid(userId, authToken);
        }

        public (List<Event>, List<ConcertEvent>) GetEvents()
        {
            return _userWebStrategy.GetEvents();
        }

        public (List<Event>, List<ConcertEvent>) GetMyEvents(int userId)
        {
            return _userWebStrategy.GetMyEvents(userId);
        }

        public bool BookEvent(int eventId, int userId)
        {
            return _userWebStrategy.BookEvent(eventId, userId);
        }
    }
}
