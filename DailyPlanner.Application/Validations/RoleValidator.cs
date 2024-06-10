using DailyPlanner.Application.Resources;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Enum;
using DailyPlanner.Domain.Interface.Validations;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Application.Validations;

public class RoleValidator : IRoleValidator
{
    public BaseResult CreateValidator(Role role)
    {
        if (role != null)
        {
            return new BaseResult
            {
                ErrorMessage = ErrorMessage.RoleAlreadyExists,
                ErrorCode = (int)ErrorCodes.RoleAlreadyExists
            };
        }
        
        return new BaseResult();
    }
    
    public BaseResult ValidateOnNull(Role role)
    {
        if (role == null)
        {
            return new BaseResult<Role>
            {
                ErrorMessage = ErrorMessage.RoleNotFound,
                ErrorCode = (int)ErrorCodes.RoleNotFound
            };
        }

        return new BaseResult();
    }
}