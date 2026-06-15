using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Services;

public interface IJwtService
{
    string GenerateToken(User user, IList<string> roles);
}