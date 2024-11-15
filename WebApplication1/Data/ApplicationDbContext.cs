using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Account> Accounts { get; set; } // Добавление DbSet для Account

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account"); // Название таблицы в нижнем регистре
                entity.HasKey(a => a.AccountId); // Primary key
                entity.Property(a => a.AccountId).HasColumnName("account_id"); // Название колонки в базе данных
                entity.Property(a => a.EmployeeId).HasColumnName("employee_id"); // Название колонки для связи с Employee
            });

            // Другие связи и настройки моделей остаются без изменений
        }
    }
}
