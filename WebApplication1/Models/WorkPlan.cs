// WorkPlan.cs
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

[Table("workplan")]
public class WorkPlan
{
    [Column("workplan_id")]
    public int WorkPlanId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [JsonIgnore] // Игнорируем, чтобы избежать циклической зависимости
    public required Employee Employee { get; set; } = null!; // Используем required и = null! для предупреждения

    [Column("hours")]
    public int Hours { get; set; }
}
