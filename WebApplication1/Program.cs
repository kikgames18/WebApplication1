using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Database connection setup (PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JSON handling setup to avoid circular references
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Cookie-based authentication setup
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login.html"; // Redirect to login page if not authenticated
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Static files
app.UseDefaultFiles();  // To use "index.html" as the main page
app.UseStaticFiles();   // Serve all static files from wwwroot folder

// Authentication endpoint
app.MapPost("/login", async (AccountDto accountDto, ApplicationDbContext db, HttpContext httpContext) =>
{
    Console.WriteLine($"POST request to /login with Username: {accountDto.Username} and Password: {accountDto.Password}"); // Debug log

    // ѕроверка сложности парол€
    if (!accountDto.IsValidPassword())
    {
        Console.WriteLine("Login failed: Password does not meet the complexity requirements."); // Debug log
        return Results.BadRequest(new { Message = "Password does not meet the complexity requirements." });
    }

    // ѕровер€ем логин и пароль в таблице account (чувствительность к регистру)
    var userAccount = await db.Accounts
        .FirstOrDefaultAsync(a => a.Login.ToLower() == accountDto.Username.ToLower() && a.Password == accountDto.Password);

    if (userAccount == null)
    {
        Console.WriteLine("Login failed: Incorrect username or password"); // Debug log
        return Results.Unauthorized();
    }

    Console.WriteLine("Login successful"); // Debug log

    // —оздаем куки дл€ авторизации
    var claims = new[] { new System.Security.Claims.Claim("name", userAccount.Login) };
    var identity = new System.Security.Claims.ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new System.Security.Claims.ClaimsPrincipal(identity);
    await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return Results.Ok(new { Message = "Logged in successfully" });
});

app.MapPost("/logout", async (HttpContext httpContext) =>
{
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Ok(new { Message = "Logged out successfully" });
});

// Sample API endpoints
app.MapGet("/api/workplans", async (ApplicationDbContext db) =>
{
    Console.WriteLine("GET request to /api/workplans"); // Debug log

    var workPlans = await db.WorkPlans
        .Include(wp => wp.Employee)
        .ThenInclude(e => e.Enterprise) // Ensure to include Enterprise correctly
        .ToListAsync();

    var workPlanDtos = workPlans.Select(wp => new WorkPlanDto
    {
        WorkPlanId = wp.WorkPlanId,
        EmployeeId = wp.EmployeeId,
        Hours = wp.Hours,
        EmployeePosition = wp.Employee.Position,
        EnterpriseId = wp.Employee.Enterprise.EnterpriseId // Make sure to access the correct property name
    });

    Console.WriteLine($"Returning {workPlanDtos.Count()} work plans"); // Debug log
    return Results.Ok(workPlanDtos);
}).RequireAuthorization();

app.Run();
