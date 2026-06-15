using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, CreateTicketResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateTicketResult> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Title = request.Title,
            Description = request.Description,
            Status = "Abierto",
            CreatedAt = DateTime.UtcNow,
            UserId = request.UserId
        };

        await _ticketRepository.AddAsync(ticket);
        await _unitOfWork.SaveChangesAsync();

        return new CreateTicketResult(true, "Ticket creado exitosamente.", ticket.TicketId);
    }
}