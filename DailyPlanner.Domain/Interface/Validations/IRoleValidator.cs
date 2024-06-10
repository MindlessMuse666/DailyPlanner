using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Validations;

public interface IRoleValidator : IBaseValidator<Role>
{
    /// <summary>
    /// Проверяет наличие роли: если роль с переданным названием уже есть в базе данных, то создать аналогичную будет невозможно
    /// </summary>
    /// <param name="role"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public BaseResult CreateValidator(Role role);
}