using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Setups.Role;
using FluentValidation;

namespace DailyPlanner.Application.Validations.FluentValidations.Role;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleValidator()
    {
        var roleProperties = new RolePropertiesSetup();
        
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name.ToString()).NotEmpty().MaximumLength(roleProperties.MaxTitleLength);
    }
}