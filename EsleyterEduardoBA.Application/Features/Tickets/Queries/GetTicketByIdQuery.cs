using EsleyterEduardoBA.Domain.Entities;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Queries;

public record GetTicketByIdQuery(int TicketId) : IRequest<Ticket?>;