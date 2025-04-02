using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Interfaces;
using KayakCove.Infrastructure.Repositories;

namespace KayakCove.Application.Services;

public class RoleService
{
    private readonly IRoleRepository _roleRepository;
    
    public RoleService(IRoleRepository roleRepository)
    {
        this._roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();

        var roleDtos = roles.Select(role => new RoleDto
        {
            Id = role.Id,
            Title = role.Title
        });

        return roleDtos;
    }

    public async Task<RoleDto> GetRoleByIdAsync(int id)
    {
        var entity = await _roleRepository.GetRoleByIdAsync(id);
        var roleDto = ConvertEntityToDto(entity);
        return roleDto;
    }

    private Role ConvertDtoToEntity(RoleDto Dto)
    {
        return new Role { Id = Dto.Id, Title = Dto.Title };
    }

    private RoleDto ConvertEntityToDto(Role Entity)
    {
        return new RoleDto { Id = Entity.Id, Title = Entity.Title };
    }
}
