using EsleyterEduardoBA.Domain.Entities;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Responses.Queries;

public record GetResponsesByTicketQuery(int TicketId) : IRequest<IEnumerable<Response>>;