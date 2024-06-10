using DailyPlanner.Domain.Enum;
using DailyPlanner.Domain.Setups.Role;

namespace DailyPlanner.Domain.Dto.Role;

public record RoleDto(long Id, RoleTitlesSetup Name);