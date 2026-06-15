using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Queries;

public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, Ticket?>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ticketRepository.GetByIdAsync(request.TicketId);
    }
}