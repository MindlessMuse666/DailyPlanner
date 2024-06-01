using AutoMapper;
using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Entity;

namespace DailyPlanner.Application.Mapping;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
    }
}