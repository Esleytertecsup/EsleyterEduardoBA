using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Repository;

public interface ITicketRepository : IRepository<Ticket>
{
    Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId);
}