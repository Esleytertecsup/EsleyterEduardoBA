using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly SistemaTicketsDbContext _context;

    public IUserRepository Users { get; }
    public IRoleRepository Roles { get; }
    public ITicketRepository Tickets { get; }
    public IResponseRepository Responses { get; }

    public UnitOfWork(
        SistemaTicketsDbContext context,
        IUserRepository users,
        IRoleRepository roles,
        ITicketRepository tickets,
        IResponseRepository responses)
    {
        _context = context;
        Users = users;
        Roles = roles;
        Tickets = tickets;
        Responses = responses;
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}