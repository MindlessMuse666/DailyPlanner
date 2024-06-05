using System.Security.Claims;
using DailyPlanner.Domain.Dto;
using DailyPlanner.Domain.Result;

namespace DailyPlanner.Domain.Interface.Services;

public interface ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims);
    
    public string GenerateRefreshToken();

    public ClaimsPrincipal GetPrincipalExpiredToken(string accessToken);

    public Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
}