using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Repository;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);
}