using AutoMapper;
using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Entity;

namespace DailyPlanner.Application.Mapping;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<Report, ReportDto>()
            .ForCtorParam(ctorParamName: "Id", m => m.MapFrom(s => s.Id))
            .ForCtorParam(ctorParamName: "Name", m => m.MapFrom(s => s.Name))
            .ForCtorParam(ctorParamName: "Description", m => m.MapFrom(s => s.Description))
            .ForCtorParam(ctorParamName: "DataCreated", m => m.MapFrom(s => s.CreatedAt))
            .ReverseMap();
    }
}