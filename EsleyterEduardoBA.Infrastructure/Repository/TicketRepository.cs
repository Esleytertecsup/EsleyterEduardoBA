using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    public TicketRepository(SistemaTicketsDbContext context) : base(context) { }

    public async Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId) =>
        await _context.Tickets
            .Where(t => t.UserId == userId)
            .ToListAsync();
}