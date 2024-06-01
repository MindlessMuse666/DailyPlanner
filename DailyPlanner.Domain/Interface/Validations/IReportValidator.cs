using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Validations;

public interface IReportValidator : IBaseValidator<Report>
{
    /// <summary>
    /// Проверяет наличие отчёта: если отчёт с переданными названием уже есть в БД, то создать аналогичный будет невозможно
    /// Проверяет пользователя: если не найден UserId, то такого пользователя не существует
    /// </summary>
    /// <param name="report"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public BaseResult CreateValidator(Report report, User user);
}