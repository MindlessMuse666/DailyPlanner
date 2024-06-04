namespace DailyPlanner.Domain.Dto.User;

public record RegisterUserDto(string Login, string Password, string PasswordConfirm);