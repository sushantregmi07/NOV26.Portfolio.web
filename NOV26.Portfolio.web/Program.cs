using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOV26.Portfolio.web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NOV26PortfoliowebContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NOV26PortfoliowebContext") ?? throw new InvalidOperationException("Connection string 'NOV26PortfoliowebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        config.LoginPath = "/Home/Login"; // Path for the redirect to user login page    
        config.AccessDeniedPath = "/home/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));


    

    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();