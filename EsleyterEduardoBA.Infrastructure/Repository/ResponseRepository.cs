using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class ResponseRepository : Repository<Response>, IResponseRepository
{
    public ResponseRepository(SistemaTicketsDbContext context) : base(context) { }

    public async Task<IEnumerable<Response>> GetByTicketIdAsync(int ticketId) =>
        await _context.Responses
            .Where(r => r.TicketId == ticketId)
            .ToListAsync();
}