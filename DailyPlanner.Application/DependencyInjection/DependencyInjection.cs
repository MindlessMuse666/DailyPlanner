using DailyPlanner.Application.Mapping;
using DailyPlanner.Application.Services;
using DailyPlanner.Application.Validations;
using DailyPlanner.Application.Validations.FluentValidations.Report;
using DailyPlanner.Application.Validations.FluentValidations.Role;
using DailyPlanner.Domain.Dto.Report;
using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Interface.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DailyPlanner.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ReportMapping));
        services.AddAutoMapper(typeof(UserMapping));
        
        InitServices(services);
    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IReportValidator, ReportValidator>();
        services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
        services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();
        
        services.AddScoped<IRoleValidator, RoleValidator>();
        services.AddScoped<IValidator<CreateRoleDto>, CreateRoleValidator>();
        services.AddScoped<IValidator<UpdateRoleDto>, UpdateRoleValidator>();

        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}