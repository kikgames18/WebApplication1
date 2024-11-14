using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public string ContactInfo { get; set; }

        public int EnterpriseId { get; set; }
    }
}
