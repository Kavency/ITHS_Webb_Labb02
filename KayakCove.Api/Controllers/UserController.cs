using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KayakCove.Application.Services;
using KayakCove.Application.DTOs;

namespace KayakCove.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        this._userService = userService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var roleDtos = await _userService.GetAllUsersAsync();
        return Ok(roleDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var roleDto = await _userService.GetUserByIdAsync(id);
        return roleDto == null ? NotFound() : Ok(roleDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
    {
        await _userService.CreateUserAsync(userDto);
        return CreatedAtAction(nameof(GetUserByIdAsync), new { id = userDto.Id }, userDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserDto userDto)
    {
        if (id != userDto.Id) return BadRequest();
        await _userService.UpdateUserAsync(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}


