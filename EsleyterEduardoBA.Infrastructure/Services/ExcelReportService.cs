using ClosedXML.Excel;
using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Services;
namespace EsleyterEduardoBA.Infrastructure.Services;
public class ExcelReportService : IExcelReportService
{
    public byte[] GenerateTicketsReport(IEnumerable<Ticket> tickets)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Tickets");
        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Título";
        worksheet.Cell(1, 3).Value = "Descripción";
        worksheet.Cell(1, 4).Value = "Estado";
        worksheet.Cell(1, 5).Value = "Fecha Creación";
        int row = 2;
        foreach (var ticket in tickets)
        {
            worksheet.Cell(row, 1).Value = ticket.TicketId;
            worksheet.Cell(row, 2).Value = ticket.Title;
            worksheet.Cell(row, 3).Value = ticket.Description;
            worksheet.Cell(row, 4).Value = ticket.Status;
            worksheet.Cell(row, 5).Value = ticket.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            row++;
        }
        worksheet.Range(1, 1, row - 1, 5).CreateTable();
        worksheet.Columns().AdjustToContents();
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
    public byte[] GenerateUsersReport(IEnumerable<User> users)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Usuarios");
        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.LightGreen;
        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Username";
        worksheet.Cell(1, 3).Value = "Email";
        int row = 2;
        foreach (var user in users)
        {
            worksheet.Cell(row, 1).Value = user.UserId;
            worksheet.Cell(row, 2).Value = user.Username;
            worksheet.Cell(row, 3).Value = user.Email;
            row++;
        }
        worksheet.Range(1, 1, row - 1, 3).CreateTable();
        worksheet.Columns().AdjustToContents();
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}