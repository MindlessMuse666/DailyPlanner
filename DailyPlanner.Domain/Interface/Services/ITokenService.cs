using System.Security.Claims;

namespace DailyPlanner.Domain.Interface.Services;

public interface ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims);
    public string GenerateRefreshToken();
}