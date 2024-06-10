using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Interface.Repositories;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Interface.Validations;
using DailyPlanner.Domain.Result;
using Microsoft.EntityFrameworkCore;

namespace DailyPlanner.Application.Services;

public class RoleService : IRoleService
{
    private readonly IBaseRepository<Role> _roleRepository;
    private readonly IBaseRepository<User> _userRepository;
    private readonly IRoleValidator _roleValidator;

    public RoleService(IBaseRepository<Role> roleRepository, IRoleValidator roleValidator, IBaseRepository<User> userRepository)
    {
        _roleRepository = roleRepository;
        _roleValidator = roleValidator;
        _userRepository = userRepository;
    }

    public async Task<BaseResult<Role>> CreateRoleAsync(CreateRoleDto dto)
    {
        var role = await _roleRepository
            .GetAll()
            .FirstOrDefaultAsync(x => x.Name == dto.Name);

        // _roleValidator.ValidateOnNull(role);
        var result = _roleValidator.CreateValidator(role);
        
        if (!result.IsSuccess)
        {
            return new BaseResult<Role>
            {
                ErrorMessage = result.ErrorMessage,
                ErrorCode = result.ErrorCode
            };
        }

        role = new Role
        {
            Name = dto.Name
        };

        await _roleRepository.CreateAsync(role);

        return new BaseResult<Role>
        {
            Data = role
        };
    }

    public async Task<BaseResult<Role>> UpdateRoleAsync(UpdateRoleDto dto)
    {
        var role = await _roleRepository
            .GetAll()
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        _roleValidator.ValidateOnNull(role);

        role.Name = dto.Name;

        await _roleRepository.UpdateAsync(role);
        
        return new BaseResult<Role>
        {
            Data = role
        };
    }

    public async Task<BaseResult<Role>> DeleteRoleAsync(long id)
    {
        var role = await _roleRepository
            .GetAll()
            .FirstOrDefaultAsync(x => x.Id == id);

        _roleValidator.ValidateOnNull(role);

        await _roleRepository.RemoveAsync(role);

        return new BaseResult<Role>
        {
            Data = role
        };
    }
}