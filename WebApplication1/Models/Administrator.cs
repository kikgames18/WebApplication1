namespace WebApplication1.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public string Login { get; set; } = string.Empty; // Инициализация по умолчанию
        public string Password { get; set; } = string.Empty; // Инициализация по умолчанию
        public string ContactInfo { get; set; } = string.Empty; // Инициализация по умолчанию
    }
}