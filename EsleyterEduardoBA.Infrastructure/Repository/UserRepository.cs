using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(SistemaTicketsDbContext context) : base(context) { }

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _context.Users.Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Username == username);

    public async Task<User?> GetByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<IList<string>> GetRolesAsync(User user) =>
        await _context.Users
            .Where(u => u.UserId == user.UserId)
            .SelectMany(u => u.Roles.Select(r => r.Name))
            .ToListAsync();
}