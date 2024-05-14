using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebReviewGame.DataAccessLayer;
using WebReviewGame.Middleware;
using WebReviewGame.Models.DBEnitity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//DI
builder.Services.AddDbContext<PostDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder .Services.AddDbContext<UserDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddIdentity<User, IdentityRole>(
    option => 
    {
        option.Password.RequiredLength = 8;
        option.Password.RequiredUniqueChars = 0;
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = false;
        option.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

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

app.UseMiddleware<RedirectToPostIndexMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
