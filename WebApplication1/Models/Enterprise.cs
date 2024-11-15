// Updated Enterprise model
using System.ComponentModel.DataAnnotations.Schema;

[Table("enterprise")]
public class Enterprise
{
    [Column("enterprise_id")] // Должно соответствовать колонке в базе данных
    public int EnterpriseId { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("working_hours")]
    public string WorkingHours { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
