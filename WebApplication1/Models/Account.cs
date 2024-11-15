using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("account")]
    public class Account
    {
        [Column("account_id")]
        public int AccountId { get; set; } // Primary key

        [Column("login")]
        public string Login { get; set; } = string.Empty; // Поле "login" в таблице

        [Column("password")]
        public string Password { get; set; } = string.Empty; // Поле "password" в таблице

        [Column("employee_id")]
        public int EmployeeId { get; set; } // Поле "employee_id" в таблице

        public Employee Employee { get; set; } = null!; // Связь с Employee, чтобы избежать значений null
    }
}
