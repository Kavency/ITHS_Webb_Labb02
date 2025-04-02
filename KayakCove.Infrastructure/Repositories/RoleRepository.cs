using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;
    public RoleRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }
}
