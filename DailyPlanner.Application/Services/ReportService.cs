﻿using AutoMapper;
using DailyPlanner.Application.Resources;
using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Enum;
using DailyPlanner.Domain.Interface.Repositories;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Interface.Validations;
using DailyPlanner.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DailyPlanner.Application.Services;

public class ReportService : IReportService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IBaseRepository<Report> _reportRepository;
    private readonly IReportValidator _reportValidator;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public ReportService(IBaseRepository<Report> reportRepository, ILogger logger, IBaseRepository<User> userRepository,
        IReportValidator reportValidator, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _logger = logger;
        _userRepository = userRepository;
        _reportValidator = reportValidator;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<CollectionResult<ReportDto>> GetReportsAsync(long userId)
    {
        ReportDto[] reports;

        try
        {
            reports = await _reportRepository.GetAll()
                .Where(x => x.UserId == userId)
                .Select(x => new ReportDto(x.Id, x.Name, x.Description, x.CreatedAt.ToLongDateString()))
                .ToArrayAsync();
        }
        catch (Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return new CollectionResult<ReportDto>()
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }

        if (!reports.Any())
        {
            _logger.Warning(ErrorMessage.ReportsNotFound, reports.Length);

            return new CollectionResult<ReportDto>()
            {
                ErrorMessage = ErrorMessage.ReportsNotFound,
                ErrorCode = (int)ErrorCodes.ReportsNotFound
            };
        }

        return new CollectionResult<ReportDto>()
        {
            Data = reports,
            Count = reports.Length
        };
    }

    /// <inheritdoc />
    public Task<BaseResult<ReportDto>> GetReportByIdAsync(long id)
    {
        ReportDto? report;

        try
        {
            report = _reportRepository.GetAll()
                .AsEnumerable()
                .Select(x => new ReportDto(x.Id, x.Name, x.Description, x.CreatedAt.ToLongDateString()))
                .FirstOrDefault(x => x.Id == id);
        }
        catch (Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return Task.FromResult(new BaseResult<ReportDto>
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            });
        }

        if (report == null)
        {
            _logger.Warning($"Отчёт с {id} не найден", id);

            return Task.FromResult(new BaseResult<ReportDto>
            {
                ErrorMessage = ErrorMessage.ReportNotFound,
                ErrorCode = (int)ErrorCodes.ReportNotFound
            });
        }

        return Task.FromResult(new BaseResult<ReportDto>
        {
            Data = report
        });
    }

    /// <inheritdoc />
    public async Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto dto)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == dto.UserId);
            var report = await _reportRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Name == dto.Name);

            var result = _reportValidator.CreateValidator(report, user);

            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            report = new Report
            {
                Name = dto.Name,
                Description = dto.Description,
                UserId = user.Id
            };

            await _reportRepository.CreateAsync(report);

            return new BaseResult<ReportDto>
            {
                Data = _mapper.Map<ReportDto>(report)
            };
        }
        catch (Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return new BaseResult<ReportDto>
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<ReportDto>> DeleteReportAsync(long id)
    {
        try
        {
            var report = await _reportRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = _reportValidator.ValidateOnNull(report);
            
            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            await _reportRepository.RemoveAsync(report);
            
            return new BaseResult<ReportDto>
            {
                Data = _mapper.Map<ReportDto>(report)
            };
        }
        catch (Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return new BaseResult<ReportDto>
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }
    }

    /// <inheritdoc />
    public async Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto dto)
    {
        try
        {
            var report = await _reportRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            var result = _reportValidator.ValidateOnNull(report);
            
            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            report.Name = dto.Name;
            report.Description = dto.Description;

            await _reportRepository.UpdateAsync(report);

            return new BaseResult<ReportDto>
            {
                Data = _mapper.Map<ReportDto>(report)
            };
        }
        catch (Exception exception)
        {
            _logger.Error(exception, exception.Message);

            return new BaseResult<ReportDto>
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }
    }
}