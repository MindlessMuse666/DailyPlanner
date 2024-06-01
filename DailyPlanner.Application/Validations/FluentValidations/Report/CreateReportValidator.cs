using DailyPlanner.Domain.Dto.Report;
using FluentValidation;

namespace DailyPlanner.Application.Validations.FluentValidations.Report;

public class CreateReportValidator : AbstractValidator<CreateReportDto>
{
    public CreateReportValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(125);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
    }
}