using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class WorkPlan
    {
        [Key]
        public int WorkPlanId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }  // Навигационное свойство

        [Required]
        public int Hours { get; set; }
    }
}
