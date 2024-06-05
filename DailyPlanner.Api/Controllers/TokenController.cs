using DailyPlanner.Domain.Dto;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Api.Controllers;

/// <summary>
/// 
/// </summary>
public class TokenController : Controller
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult<BaseResult<TokenDto>>> RefreshToken([FromBody] TokenDto dto)
    {
        var response = await _tokenService.RefreshToken(dto);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }
}