using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
namespace event_platform.DataHandlers
{
	public class UseDBContext : IdentityDbContext
	{
		public UseDBContext(DbContextOptions<UseDBContext> options) : base(options)
		{
	
		}
	}
}

