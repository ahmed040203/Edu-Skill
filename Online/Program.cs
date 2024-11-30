using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online.Data;
using Online.Models;
using Online.Repository;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
{
    options.LoginPath = "/Account/SignIn";
    options.LogoutPath = "/Account/SignOut";
    options.Cookie.Name = "Online-Learning";
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(connection);
});


builder.Services.AddIdentity<Users, IdentityRole>(
                config =>
                {

                    config.Password.RequiredUniqueChars = 2;
                    config.Password.RequireDigit = true;
                    config.Password.RequireLowercase = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequireNonAlphanumeric = true;
                    config.User.RequireUniqueEmail = true;
                    config.Lockout.MaxFailedAccessAttempts = 5;
                    config.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(5);
                    config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
                }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(
                config =>
                {
                    config.LoginPath = "/Account/SignIn";
                    config.ExpireTimeSpan = System.TimeSpan.FromDays(5);
                    config.SlidingExpiration = true;
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
