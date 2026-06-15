using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public record UpdateTicketCommand(
    int TicketId,
    string Title,
    string Description,
    string Status
) : IRequest<UpdateTicketResult>;

public record UpdateTicketResult(bool Success, string Message);