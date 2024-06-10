using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Services;

/// <summary>
/// Сервис, который управляет ролями
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Создание роли
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<BaseResult<Role>> CreateRoleAsync(CreateRoleDto dto);
    
    /// <summary>
    /// Обновление роли
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<BaseResult<Role>> UpdateRoleAsync(UpdateRoleDto dto);
    
    /// <summary>
    /// Удаление роли
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BaseResult<Role>> DeleteRoleAsync(long id);
}