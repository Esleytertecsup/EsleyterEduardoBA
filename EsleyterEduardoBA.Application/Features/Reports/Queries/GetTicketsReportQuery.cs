using MediatR;

namespace EsleyterEduardoBA.Application.Features.Reports.Queries;

public record GetTicketsReportQuery : IRequest<byte[]>;