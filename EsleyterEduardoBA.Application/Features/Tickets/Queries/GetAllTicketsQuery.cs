using EsleyterEduardoBA.Domain.Entities;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Tickets.Queries;

public record GetAllTicketsQuery : IRequest<IEnumerable<Ticket>>;