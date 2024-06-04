using AutoMapper;
using DailyPlanner.Domain.Dto.User;
using DailyPlanner.Domain.Entity;

namespace DailyPlanner.Application.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}