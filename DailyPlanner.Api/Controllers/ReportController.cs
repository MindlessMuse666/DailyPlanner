using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

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