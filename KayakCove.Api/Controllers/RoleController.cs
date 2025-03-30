using KayakCove.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayakCove.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        this._roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roleDtos = await _roleService.GetAllRolesAsync();
        return Ok(roleDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var roleDto = await _roleService.GetRoleByIdAsync(id);
        return roleDto == null ? NotFound() : Ok(roleDto);
    }
}
