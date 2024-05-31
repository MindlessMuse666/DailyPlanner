namespace DailyPlanner.Domain.Interface;

public interface IEntityId<T> where T : struct
{
    public T Id { get; set; }
}