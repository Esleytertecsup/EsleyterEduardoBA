using EsleyterEduardoBA.Application.Features.Tickets.Commands;
using EsleyterEduardoBA.Application.Features.Tickets.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsleyterEduardoBA.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _mediator.Send(new GetTicketByIdQuery(id));
        if (ticket is null)
            return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(result);
        return CreatedAtAction(nameof(GetById), new { id = result.TicketId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTicketCommand command)
    {
        if (id != command.TicketId)
            return BadRequest("El ID de la ruta no coincide con el del body.");

        var result = await _mediator.Send(command);
        if (!result.Success)
            return NotFound(result);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteTicketCommand(id));
        if (!result.Success)
            return NotFound(result);
        return Ok(result);
    }
}