using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Data;
using KayakCove.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.Include(u => u.Role).ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> AuthenticateUserAsync(string username, string password)
    {
        var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        return user;
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        return HandleResult(await _context.SaveChangesAsync());
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        return HandleResult(await _context.SaveChangesAsync());
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        return HandleResult(await _context.SaveChangesAsync());
        
    }

    private bool HandleResult(int result)
    {
        if (result > 0)
            return true;
        else
            return false;
    }
}
