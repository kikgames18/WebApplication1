public class AccountDto
{
    public required string Username { get; set; } = string.Empty; // Имя пользователя (логин)
    public required string Password { get; set; } = string.Empty; // Пароль

    public bool IsValidPassword()
    {
        if (Password.Length < 8)
            return false;

        bool hasUpper = Password.Any(char.IsUpper);
        bool hasLower = Password.Any(char.IsLower);
        bool hasDigit = Password.Any(char.IsDigit);
        bool hasSpecialChar = Password.Any(ch => !char.IsLetterOrDigit(ch));

        return hasUpper && hasLower && hasDigit && hasSpecialChar;
    }
}
