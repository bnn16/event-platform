using System;
using event_platform.Models;
using event_platform.State;
using System.Security.Cryptography;
using System.Text;

namespace event_platform.DataHandlers
{
	public static class UserHandler
	{
		public static bool UserExists(string username)
		{
			return UserState.Users.Any(u => u.Username == username);
		}

		public static bool AuthenticateUser(string username, string password)
		{
			var user = UserState.Users.Find(u => u.Username == username);
			if (user == null) {
				return false;
			}

			var hashedPassword = HashPassword(password, user.Salt);
			return hashedPassword == user.Password;
		}

		public static void AddUser(string username, string password)
		{
			var salt = GenerateSalt();
			var hashedPassword = HashPassword(password, salt);
			var user = new User(username, hashedPassword, salt);
			UserState.Users.Add(user);
		}

		private static string HashPassword(string password, string salt)
		{
			var saltedPassword = password + salt;
			var bytes = Encoding.UTF8.GetBytes(saltedPassword);
			var hash = SHA256.Create().ComputeHash(bytes);
			var hashedPassword = ConvertToHexString(hash);
			return hashedPassword;
		}

		private static string GenerateSalt()
		{
			const int saltLength = 16;
			var random = new RNGCryptoServiceProvider();
			var saltBytes = new byte[saltLength];
			random.GetBytes(saltBytes);
			var salt = ConvertToHexString(saltBytes);
			return salt;
		}

		private static string ConvertToHexString(byte[] bytes)
		{
			var builder = new StringBuilder();
			foreach (var b in bytes) {
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}
	}
}

