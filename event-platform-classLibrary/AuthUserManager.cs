using DAL;
using event_platform_classLibrary.EventHandlers.Classes;
using Microsoft.AspNetCore.Http;

namespace event_platform_classLibrary
{
    public class AuthUserManager
    {
        private readonly IUserDBController _userController;
        private readonly IDBController _dbController;

        public AuthUserManager(IUserDBController userController, IDBController dbController)
        {
            _userController = userController;
            _dbController = dbController;
        }

        public bool IsAuthenticated(IRequestCookieCollection cookies, out int userId)
        {
            userId = -1;

            if (cookies["AuthToken"] == null || cookies["UserId"] == null)
            {
                return false;
            }

            userId = int.Parse(cookies["UserId"]);
            string authToken = cookies["AuthToken"];

            return _userController.IsAuthTokenValid(userId, authToken);
        }

        public User GetAuthenticatedUser(int userId)
        {
            return _userController.GetUserById(userId);
        }

        public bool AuthenticateUser(LoginBindModel input, out User user)
        {
            user = _userController.GetUserByUsernameOrEmail(input);

            if (user != null && BCrypt.Net.BCrypt.Verify(input.Password, user.PasswordHash))
            {
                return true;
            }

            return false;
        }

        public bool IsAuthorized(User user)
        {
            return user.Role == "User";
        }

        public void SetAuthCookies(IResponseCookies cookies, User user)
        {
            _userController.DeleteAuthToken(user.Id);

            var authToken = Guid.NewGuid().ToString();
            _userController.InsertAuthToken(user.Id, authToken);

            cookies.Append("AuthToken", authToken, new CookieOptions { HttpOnly = true });
            cookies.Append("UserId", user.Id.ToString(), new CookieOptions { HttpOnly = true });
        }

        public async Task<bool> RegisterUserAsync(RegisterBindModel input)
        {
            return await _userController.RegisterUserAsync(input);
        }

        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            return _userController.GetUserByUsernameOrEmail(usernameOrEmail);
        }

        public async Task<bool> UpdateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email))
            {
                return false;
            }

            var existingUser = _userController.GetUserByUsernameOrEmail(user.Username);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                return false;
            }

            existingUser = _userController.GetUserByUsernameOrEmail(user.Email);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                return false;
            }

            return await _userController.UpdateUserAsync(user);
        }

        public void SaveUserTags(User user)
        {
            _userController.SaveTags(user);
        }
    }
}
