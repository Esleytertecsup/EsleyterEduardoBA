using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(SistemaTicketsDbContext context) : base(context) { }

    public async Task<Role?> GetByNameAsync(string name) =>
        await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
}