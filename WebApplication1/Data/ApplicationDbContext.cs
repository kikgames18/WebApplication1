using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}