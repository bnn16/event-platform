using event_platform_classLibrary.EventHandlers.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        bool AddBooking(int eventId, int userId);
        void UpdateEvent(Event updatedEvent);
        bool HasBookedEvent(int eventId, int userId);
    }
}

