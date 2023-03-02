using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using event_platform.DataHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace event_platform
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<UseDBContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
			});

			services.AddIdentity<IdentityUser, IdentityRole>(
					options =>
					{
						options.Password.RequiredLength = 8;
						options.Password.RequireUppercase = true;
						options.Password.RequireLowercase = true;
						options.Lockout.MaxFailedAccessAttempts = 5;
						options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
						options.User.RequireUniqueEmail = true;
						options.SignIn.RequireConfirmedEmail = true;
					}
				).AddEntityFrameworkStores<UseDBContext>().AddDefaultTokenProviders();
			

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Account/Login";
				options.AccessDeniedPath= "/Account/AccessDenied";

			});
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}

