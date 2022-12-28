using realEstateWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using realEstateWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true)
                    .AddUserSecrets<Program>().Build();

var dbServer = config["ConnectionStrings:reWebAppCnn"];

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inject the connection string when the application is loaded
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbServer));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default SignIn settings.
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.User.RequireUniqueEmail = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

