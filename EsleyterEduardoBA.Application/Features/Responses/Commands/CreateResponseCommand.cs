using MediatR;

namespace EsleyterEduardoBA.Application.Features.Responses.Commands;

public record CreateResponseCommand(
    string Content,
    int TicketId,
    int UserId
) : IRequest<CreateResponseResult>;

public record CreateResponseResult(bool Success, string Message, int ResponseId);