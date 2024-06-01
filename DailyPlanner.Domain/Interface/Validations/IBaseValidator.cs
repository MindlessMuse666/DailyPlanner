using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Validations;

public interface IBaseValidator<in T> where T : class
{
    public BaseResult ValidateOnNull(T model);
}