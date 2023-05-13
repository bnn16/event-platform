using event_platform_classLibrary.EventHandlers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers.UserStrategy
{
    public interface IUserWebStrategy
    {
        User GetUserByUsernameOrEmail(string usernameOrEmail);
        Task<bool> RegisterUserAsync(RegisterBindModel input);
        void InsertAuthToken(int userId, string token);
        void DeleteAuthToken(int userId);
        bool IsAuthTokenValid(int userId, string authToken);
        (List<Event>, List<ConcertEvent>) GetEvents();
        (List<Event>, List<ConcertEvent>) GetMyEvents(int userId);
        bool BookEvent(int eventid,int user);
        bool HasBookedEvent(int userId);
        bool HasBookedEvent(int eventid, int userId);
    }

}
