using DailyPlanner.Domain.Dto;
using DailyPlanner.Domain.Dto.User;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Services;

/// <summary>
/// Сервис, который предназначен для авторизации/регистрации пользователя
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<BaseResult<UserDto>> Register(RegisterUserDto dto);
    
    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
}