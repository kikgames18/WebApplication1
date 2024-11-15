public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string Position { get; set; } = string.Empty; // Убедитесь, что значение по умолчанию не null
    public string ContactInfo { get; set; } = string.Empty; // Убедитесь, что значение по умолчанию не null
    public int EnterpriseId { get; set; }
}
