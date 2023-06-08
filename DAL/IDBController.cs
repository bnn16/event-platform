using event_platform_classLibrary.EventHandlers.Classes;
using System.Data;

namespace event_platform_classLibrary
{
    public interface IDBController
    {
        Task<bool> AddEventAsync(Event _event);
        Task<bool> UpdateEventAsync(Event _event, int rId, string artist = null, string venue = null);
        Task<bool> AddConcertAsync(ConcertEvent _event);
        Task<bool> DeleteEvent(int id);
        DataTable GetAllEvents();
        (List<Event>, List<ConcertEvent>) GetListOfEvents();
        (List<Event>, List<ConcertEvent>) GetMyEvents(int userId);
        DataSet GetEventById(int id);
        Event GetEventByIdObj(int eventId);
        DataTable GetEventByFilter(string filter);
        User GetUserByUsernameOrEmail(string usernameOrEmail);
        User GetUserByUsernameOrEmail(LoginBindModel input);
        Task<bool> RegisterUserAsync(RegisterBindModel Input);
        void InsertAuthToken(int userId, string token);
        void DeleteAuthToken(int userId);
        bool IsAuthTokenValid(int userId, string authToken);
        User GetUserById(int userId);
        bool AddBooking(int eventId, int userId, string code);
        void UpdateEvent(Event updatedEvent);
        bool HasBookedEvent(int eventId, int userId);
        Event GetEventByIdObjObj(int id);
        string GetBookingCodeForUserEvent(int userId, int eventId);
        bool UnBookEvent(int eventId, int userId);
        Task<bool> AddEventTags(int eventId, string tag);
        List<(int eventId, string tag)> GetAllEventTags();
        List<string> GetAllUserTags(int userId);
        bool CheckBooking(string code);
        void DeleteBooking(string code);
    }
}

