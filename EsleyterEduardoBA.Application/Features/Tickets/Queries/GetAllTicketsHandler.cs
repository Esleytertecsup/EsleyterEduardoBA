using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Queries;

public class GetAllTicketsHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<Ticket>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetAllTicketsHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _ticketRepository.GetAllAsync();
    }
}