using System;
using System.Net.NetworkInformation;

namespace event_platform.Models
{
	public class User
	{

		public string Username { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public ScopeLevel AuthLevel { get; set; }

		public User(string cUser, string cPassword, string cSalt)
		{
			this.AuthLevel = ScopeLevel.User;
			this.Username = cUser;
			this.Password = cPassword;
			this.Salt = cSalt;
		}
	}

}

