using DAL;
using event_platform_classLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDBController, DBController>();
builder.Services.AddScoped<IUserDBController, UserDBController>();
builder.Services.AddRazorPages();

builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// Middleware to redirect to /landing on first access
bool isFirstAccess = true;
app.Use(async (context, next) =>
{
    if (isFirstAccess)
    {
        isFirstAccess = false;
        context.Response.Redirect("/landing");
    }
    else
    {
        await next.Invoke();
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
