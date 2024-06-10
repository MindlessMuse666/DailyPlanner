using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Setups.Role;
using FluentValidation;

namespace DailyPlanner.Application.Validations.FluentValidations.Role;

public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        var roleProperties = new RolePropertiesSetup();

        RuleFor(x => x.Name.ToString()).NotEmpty().MaximumLength(roleProperties.MaxTitleLength);
    }
}