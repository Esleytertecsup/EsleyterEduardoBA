using MediatR;

namespace EsleyterEduardoBA.Application.Features.Reports.Queries;

public record GetUsersReportQuery : IRequest<byte[]>;