using System.Net.Mime;
using DailyPlanner.Domain.Dto.Role;
using DailyPlanner.Domain.Entity;
using DailyPlanner.Domain.Interface.Services;
using DailyPlanner.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner.Api.Controllers;

[Consumes(MediaTypeNames.Application.Json)]
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    /// <summary>
    /// Создание новой роли
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Sample request for create role:
    ///
    ///     POST
    ///     {
    ///         "name": "User"
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Роль была успешно создана</response>
    /// <response code="400">Роль не была создана</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<Role>>> Create([FromBody] CreateRoleDto dto)
    {
        var response = await _roleService.CreateRoleAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// Обновление роли с указанием основных свойств
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Sample request for update role:
    ///
    ///     PUT
    ///     {
    ///         "id": 1,
    ///         "name": "User"
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Роль успешно обновлена</response>
    /// <response code="400">Роль не была обновлена</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<Role>>> Update([FromBody] UpdateRoleDto dto)
    {
        var response = await _roleService.UpdateRoleAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    /// <summary>
    /// Удаление роли по id
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// Sample request for delete role:
    ///
    ///     DELETE
    ///     {
    ///         "id": 1
    ///     }
    /// 
    /// </remarks>
    /// <response code="200">Роль была успешно удалена</response>
    /// <response code="400">Роль не была удалена</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResult<Role>>> Delete(long id)
    {
        var response = await _roleService.DeleteRoleAsync(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}