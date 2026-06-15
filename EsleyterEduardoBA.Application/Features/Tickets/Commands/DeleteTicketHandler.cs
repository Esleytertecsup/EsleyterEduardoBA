using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, DeleteTicketResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteTicketResult> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
        if (ticket is null)
            return new DeleteTicketResult(false, "Ticket no encontrado.");

        _ticketRepository.Delete(ticket);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteTicketResult(true, "Ticket eliminado exitosamente.");
    }
}