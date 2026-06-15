using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, UpdateTicketResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateTicketResult> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
        if (ticket is null)
            return new UpdateTicketResult(false, "Ticket no encontrado.");

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Status = request.Status;

        _ticketRepository.Update(ticket);
        await _unitOfWork.SaveChangesAsync();

        return new UpdateTicketResult(true, "Ticket actualizado exitosamente.");
    }
}