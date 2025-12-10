
using Application.Interfaces;
using Application.Services;
using Domain.Users;
using Infrastructure.EF_Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("InRamDb");
});

#region IOC
builder.Services.AddScoped<IAccountingServise, AccountingServise>();
builder.Services.AddScoped<IAdminService, AdminService>();

#endregion


#region identity 
builder.Services.AddAuthentication(p =>
{
    p.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    p.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    p.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(p =>
{
    p.LoginPath = "/Home/Index";
    p.LogoutPath = "/Home/Logout";
    p.ExpireTimeSpan = TimeSpan.FromDays(1);
});
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Users.Add(new User
    {
        UserId = -1,
        UserName = "Admin",
        Password = "1234",
        Role = Domain.Users.Enums.UserRole.Admin
    });
    context.SaveChanges();

}

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
