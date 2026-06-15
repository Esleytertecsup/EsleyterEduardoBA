using EsleyterEduardoBA.Domain.Entities;

namespace EsleyterEduardoBA.Domain.Ports.Services;

public interface IExcelReportService
{
    byte[] GenerateTicketsReport(IEnumerable<Ticket> tickets);
    byte[] GenerateUsersReport(IEnumerable<User> users);
}