using KayakCove.Domain.Entities;

namespace KayakCove.Infrastructure.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int id);
}
