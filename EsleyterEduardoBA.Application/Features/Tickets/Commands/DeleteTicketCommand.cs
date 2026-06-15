using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Commands;

public record DeleteTicketCommand(int TicketId) : IRequest<DeleteTicketResult>;

public record DeleteTicketResult(bool Success, string Message);