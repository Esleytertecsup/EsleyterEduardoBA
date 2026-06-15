using EsleyterEduardoBA.Application.Features.Roles.Commands;
using EsleyterEduardoBA.Application.Features.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsleyterEduardoBA.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetRoleByIdQuery { RoleId = id });
        if (result is null) return NotFound(new { message = "Rol no encontrado" });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleCommand command)
    {
        command.RoleId = id;
        var result = await _mediator.Send(command);
        if (result is null) return NotFound(new { message = "Rol no encontrado para actualizar" });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteRoleCommand { RoleId = id });
        if (!success) return NotFound(new { message = "Rol no encontrado para eliminar" });
        return Ok(new { message = "Rol eliminado correctamente" });
    }
}