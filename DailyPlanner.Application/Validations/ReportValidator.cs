using DailyPlanner.Application.Resources;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Enum;
using DailyPlanner.Domain.Interface.Validations;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Application.Validations;

public class ReportValidator : IReportValidator
{
    public BaseResult CreateValidator(Report report, User user)
    {
        if (report != null)
        {
            return new BaseResult
            {
                ErrorMessage = ErrorMessage.ReportAlreadyExists,
                ErrorCode = (int)ErrorCodes.ReportAlreadyExists
            };
        }

        if (user == null)
        {
            return new BaseResult
            {
                ErrorMessage = ErrorMessage.UserNotFound,
                ErrorCode = (int)ErrorCodes.UserNotFound
            };
        }
        
        return new BaseResult();
    }
    
    public BaseResult ValidateOnNull(Report model)
    {
        if (model == null)
        {
            return new BaseResult
            {
                ErrorMessage = ErrorMessage.ReportNotFound,
                ErrorCode = (int)ErrorCodes.ReportNotFound
            };
        }

        return new BaseResult();
    }
}