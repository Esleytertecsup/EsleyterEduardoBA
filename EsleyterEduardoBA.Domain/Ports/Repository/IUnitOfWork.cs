namespace EsleyterEduardoBA.Domain.Ports.Repository;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    ITicketRepository Tickets { get; }
    IResponseRepository Responses { get; }
    Task<int> SaveChangesAsync();
}