using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Repository;

public interface IResponseRepository : IRepository<Response>
{
    Task<IEnumerable<Response>> GetByTicketIdAsync(int ticketId);
}