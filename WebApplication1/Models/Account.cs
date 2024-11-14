using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }
    }
}
