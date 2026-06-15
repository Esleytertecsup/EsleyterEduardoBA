using EsleyterEduardoBA.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EsleyterEduardoBA.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("tickets")]
    [ProducesResponseType(typeof(FileContentResult), 200)]
    public async Task<IActionResult> GetTicketsReport()
    {
        var fileBytes = await _mediator.Send(new GetTicketsReportQuery());
        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_tickets.xlsx"
        );
    }
    [HttpGet("users")]
    [ProducesResponseType(typeof(FileContentResult), 200)]
    public async Task<IActionResult> GetUsersReport()
    {
        var fileBytes = await _mediator.Send(new GetUsersReportQuery());
        return File(
            fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_usuarios.xlsx"
        );
    }
}