using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Domain.Ports.Services;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Reports.Queries;

public class GetUsersReportHandler : IRequestHandler<GetUsersReportQuery, byte[]>
{
    private readonly IUserRepository _userRepository;
    private readonly IExcelReportService _excelReportService;

    public GetUsersReportHandler(
        IUserRepository userRepository,
        IExcelReportService excelReportService)
    {
        _userRepository = userRepository;
        _excelReportService = excelReportService;
    }

    public async Task<byte[]> Handle(GetUsersReportQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return _excelReportService.GenerateUsersReport(users);
    }
}