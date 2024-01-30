using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.Interfaces;
using SchoolSystem.Repository;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Models;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolSystemCnn")));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3; // Minimum length
    options.Password.RequireNonAlphanumeric = false; // Set to true if you want non-alphanumeric characters
    options.Password.RequireDigit = false; // Set to true if you want at least one digit
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();




builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
   pattern: "{controller=Account}/{action=Login}/{id?}");

using (var scope = app.Services.CreateScope())
{
    string[] roleNames = { "Admin", "Lecturer" };

    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            //create the roles and seed them to the database: Question 1
            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    //Here you could create a super user who will maintain the web app
    string userName = "admin";
    string email = "admin@gmail.com";
    string password = "Test12345!";
    //Here you could create a super user who will maintain the web app
    var poweruser = new ApplicationUser
    {
        FullName = userName,
        UserName = userName,
        Email = email,
        Gender = "Male",
        EmailConfirmed = true
    };
    //Ensure you have these values in your appsettings.json file
    string userPWD = password;
    var _user = await UserManager.FindByEmailAsync(email);


    if (_user == null)
    {
       var userData = await UserManager.CreateAsync(poweruser, userPWD);


        //here we tie the new user to the role
        var userInfoData = await UserManager.AddToRoleAsync(poweruser, "Admin");

       
    }
}

app.Run();
