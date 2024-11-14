using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к базе данных PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Использование статических файлов
app.UseDefaultFiles();  // Для использования "index.html" как основной страницы
app.UseStaticFiles();   // Для обслуживания всех статических файлов из папки wwwroot

// Примеры API эндпоинтов
app.MapGet("/api/workplans", async (ApplicationDbContext db) =>
    await db.WorkPlans.Include(wp => wp.Employee).ToListAsync());


app.MapPost("/api/workplans", async (WorkPlan workPlan, ApplicationDbContext db) =>
{
    await db.WorkPlans.AddAsync(workPlan);
    await db.SaveChangesAsync();
    return workPlan;
});

// Другие эндпоинты...

app.Run();
