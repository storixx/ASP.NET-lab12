using Microsoft.EntityFrameworkCore;
using WebApplication12.Data;
using WebApplication12.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<SecondDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SecondDbConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    
    var user1 = new User { FirstName = "fName1", LastName = "lName1", Age = 11 };
    var user2 = new User { FirstName = "fName2", LastName = "lName2", Age = 22 };
    var user3 = new User { FirstName = "fName3", LastName = "lName3", Age = 33 };
    
    context.Users.AddRange(user1, user2, user3);
    
    context.SaveChanges();
    
    var users = context.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName} {user.LastName}, Age: {user.Age}");
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Companies}/{action=Index}/{id?}");

app.Run();