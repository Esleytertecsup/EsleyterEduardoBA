using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public record CreateTicketCommand(
    string Title,
    string Description,
    int UserId
) : IRequest<CreateTicketResult>;

public record CreateTicketResult(bool Success, string Message, int TicketId);