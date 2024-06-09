using Asp.Versioning;
using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    /// <summary>
    /// Получение всех доступных отчётов пользователя по userId
    /// </summary>
    /// <param name="userId"></param>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET
    ///     {
    ///         "id": 1
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Все доступные отчёты были успешно получены</response>
    /// <response code="400">Отчёты не были получены</response>
    [HttpGet("reports/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetUserReports(long userId)
    {
        var response = await _reportService.GetReportsAsync(userId);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    /// <summary>
    /// Получение отчёта пользователя по id отчёта
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET
    ///     {
    ///         "id": 1
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Отчёт был успешно получен</response>
    /// <response code="400">Отчёт не был получен</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetReport(long id)
    {
        var response = await _reportService.GetReportByIdAsync(id);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }
    
    /// <summary>
    /// Удаление отчёта пользователя по id отчёта
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE
    ///     {
    ///         "id": 1
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Отчёт был успешно удалён</response>
    /// <response code="400">Отчёт не был удалён</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<ReportDto>>> DeleteReport(long id)
    {
        var response = await _reportService.DeleteReportAsync(id);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }
    
    /// <summary>
    /// Создание нового отчёта пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Request for create report:
    ///
    ///     POST
    ///     {
    ///         "name": "Test report",
    ///         "description": "Test report description",
    ///         "userId": 1
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Отчёт был успешно создан</response>
    /// <response code="400">Отчёт не был создан</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<ReportDto>>> CreateReport([FromBody] CreateReportDto dto)
    {
        var response = await _reportService.CreateReportAsync(dto);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }
    
    /// <summary>
    /// Обновление отчёта пользователя с указанием основных свойств
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT
    ///     {
    ///         "id": 1,
    ///         "name": "Report 1",
    ///         "description": "Test report description"
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Отчёт был успешно обновлён</response>
    /// <response code="400">Отчёт не был обновлён</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<ReportDto>>> UpdateReport([FromBody] UpdateReportDto dto)
    {
        var response = await _reportService.UpdateReportAsync(dto);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }
}