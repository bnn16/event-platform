
using event_platform_classLibrary.EventHandlers.Classes;
using event_platform_classLibrary;

namespace DAL
{
    public interface IUserDBController
    {
        List<User> GetAllUsers();
        User GetUserByUsernameOrEmail(string usernameOrEmail);
        User GetUserByUsernameOrEmail(LoginBindModel input);
        Task<bool> RegisterUserAsync(RegisterBindModel input);
        void InsertAuthToken(int userId, string token);
        void DeleteAuthToken(int userId);
        bool IsAuthTokenValid(int userId, string authToken);
        User GetUserById(int userId);

        void InsertSickLeave(int userId, DateTime start, DateTime end, string description);

        Task<bool> UpdateUserAsync(User user);
    }
}