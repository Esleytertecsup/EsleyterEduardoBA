using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
    Task<IList<string>> GetRolesAsync(User user);
}