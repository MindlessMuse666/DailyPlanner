using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Services;

/// <summary>
/// Сервис, который отвечает за работу доменной части отчёта (Report)
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Получение всех отчётов пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<CollectionResult<ReportDto>> GetReportsAsync(long userId);
    
    /// <summary>
    /// Получение отчёта пользователя по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BaseResult<ReportDto>> GetReportByIdAsync(long id);
    
    /// <summary>
    /// Создание отчёта с базовыми параметрами
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto dto);

    /// <summary>
    /// Удаление отчёта по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BaseResult<ReportDto>> DeleteReportAsync(long id);

    /// <summary>
    /// Обновление отчёта
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto dto);
}