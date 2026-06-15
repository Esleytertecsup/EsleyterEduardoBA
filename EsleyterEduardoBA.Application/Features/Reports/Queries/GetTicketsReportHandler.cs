using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Domain.Ports.Services;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Reports.Queries;

public class GetTicketsReportHandler : IRequestHandler<GetTicketsReportQuery, byte[]>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IExcelReportService _excelReportService;

    public GetTicketsReportHandler(
        ITicketRepository ticketRepository,
        IExcelReportService excelReportService)
    {
        _ticketRepository = ticketRepository;
        _excelReportService = excelReportService;
    }

    public async Task<byte[]> Handle(GetTicketsReportQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetAllAsync();
        return _excelReportService.GenerateTicketsReport(tickets);
    }
}