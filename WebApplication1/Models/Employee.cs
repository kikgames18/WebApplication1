// Updated Employee model
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

[Table("employee")]
public class Employee
{
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("position")]
    public required string Position { get; set; }

    [Column("hire_date")]
    public DateTime HireDate { get; set; }

    [Column("contact_info")]
    public required string ContactInfo { get; set; }

    [Column("enterprise_id")]
    public int EnterpriseId { get; set; }

    [JsonIgnore] // Игнорируем, чтобы избежать циклической зависимости
    [ForeignKey("EnterpriseId")]
    public Enterprise Enterprise { get; set; } = null!;

    [JsonIgnore] // Игнорируем, чтобы избежать циклической зависимости
    public ICollection<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();
}
