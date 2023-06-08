using DAL;
using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary
{
    public class UserManager
    {
        private readonly IUserDBController _userController;
        private readonly IDBController _dbController;

        public UserManager(IUserDBController userController, IDBController dbController)
        {
            _userController = userController;
            _dbController = dbController;
        }

        public bool BookEvent(int eventId, int userId, string code)
        {
            if (HasBookedEvent(eventId, userId))
            {
                return false;
            }

            Event eventObj = _dbController.GetEventByIdObj(eventId);
            if (eventObj.Capacity <= 0)
            {
                return false;
            }

            Booking booking = new Booking
            {
                UserId = userId,
                EventId = eventId,
            };
            _dbController.AddBooking(booking.EventId, userId, code);

            eventObj.Capacity--;
            _dbController.UpdateEvent(eventObj);

            return true;
        }

        public bool HasBookedEvent(int eventId, int userId)
        {
            return _dbController.HasBookedEvent(eventId, userId);
        }

        public bool UnBookevent(int eventId, int userId)
        {
            return _dbController.UnBookEvent(eventId, userId);
        }

        public (List<Event>, List<ConcertEvent>) GetEvents()
        {
            return _dbController.GetListOfEvents();
        }

        public (List<Event>, List<ConcertEvent>) GetEventsUser(int id)
        {
            return _dbController.GetMyEvents(id);
        }

        public string GetBookingCodeForUserEvent(int userId, int eventId)
        {
            return _dbController.GetBookingCodeForUserEvent(userId, eventId);
        }
    }
}