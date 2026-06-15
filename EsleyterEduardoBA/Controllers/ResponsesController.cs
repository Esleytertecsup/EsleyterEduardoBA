using EsleyterEduardoBA.Application.Features.Responses.Commands;
using EsleyterEduardoBA.Application.Features.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsleyterEduardoBA.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResponsesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ticket/{ticketId}")]
    public async Task<IActionResult> GetByTicket(int ticketId)
    {
        var responses = await _mediator.Send(new GetResponsesByTicketQuery(ticketId));
        return Ok(responses);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateResponseCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }
}