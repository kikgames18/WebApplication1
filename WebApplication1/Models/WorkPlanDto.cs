public class WorkPlanDto
{
    public int WorkPlanId { get; set; }
    public int EmployeeId { get; set; }
    public int Hours { get; set; }
    public string EmployeePosition { get; set; } = string.Empty; // Добавьте, если хотите отображать позицию
    public int EnterpriseId { get; set; } // Для отображения ID предприятия
}
