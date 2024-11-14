using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����������� � ���� ������ PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ������������� ����������� ������
app.UseDefaultFiles();  // ��� ������������� "index.html" ��� �������� ��������
app.UseStaticFiles();   // ��� ������������ ���� ����������� ������ �� ����� wwwroot

// ������� API ����������
app.MapGet("/api/workplans", async (ApplicationDbContext db) =>
    await db.WorkPlans.Include(wp => wp.Employee).ToListAsync());


app.MapPost("/api/workplans", async (WorkPlan workPlan, ApplicationDbContext db) =>
{
    await db.WorkPlans.AddAsync(workPlan);
    await db.SaveChangesAsync();
    return workPlan;
});

// ������ ���������...

app.Run();
