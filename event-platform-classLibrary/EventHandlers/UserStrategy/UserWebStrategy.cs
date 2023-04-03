using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers.UserStrategy
{
    public class UserWebStrategy : IUserWebStrategy
    {
        private readonly DBController _dbController;

        public UserWebStrategy(DBController dbController)
        {
            _dbController = dbController;
        }

        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            return _dbController.GetUserByUsernameOrEmail(usernameOrEmail);
        }

        public async Task<bool> RegisterUserAsync(RegisterBindModel input)
        {
            return await _dbController.RegisterUserAsync(input);
        }

        public async void InsertAuthToken(int userId, string token)
        {
            _dbController.InsertAuthToken(userId, token);
        }

        public void DeleteAuthToken(int userId)
        {
            _dbController.DeleteAuthToken(userId);
        }

        public bool IsAuthTokenValid(int userId, string authToken)
        {
            return _dbController.IsAuthTokenValid(userId, authToken);
        }

        public (List<Event>, List<ConcertEvent>) GetEvents()
        {
            return _dbController.GetListOfEvents();
        }

        public (List<Event>, List<ConcertEvent>) GetMyEvents(int userId)
        {
            return _dbController.GetMyEvents(userId);

            // Implementation of GetConcertEvents method
        }
        public bool BookEvent(int eventId, int userId)
        {
            if (HasBookedEvent(eventId, userId))
            {
                return false; // User already booked this event, so return false
            }

            // Check if the event has available capacity
            Event eventObj = _dbController.GetEventByIdObj(eventId);
            if (eventObj.Capacity <= 0)
            {
                return false; // Event is already full, so return false
            }

            // Create a new Booking object and add it to the database
            Booking booking = new Booking
            {
                UserId = userId,
                EventId = eventId,
            };
            _dbController.AddBooking(booking.EventId, userId);

            // Update the available capacity of the event in the database
            eventObj.Capacity--;
            _dbController.UpdateEvent(eventObj);

            return true; // Booking was successful, so return true
        }


        public bool HasBookedEvent(int eventId, int userId)
        {
            return _dbController.HasBookedEvent(eventId, userId) != null;
        }

        public bool HasBookedEvent(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
