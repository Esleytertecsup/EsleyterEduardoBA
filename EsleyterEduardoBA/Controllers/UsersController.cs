using EsleyterEduardoBA.Application.Features.Users.Commands;
using EsleyterEduardoBA.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsleyterEduardoBA.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery { UserId = id });
        if (result is null) return NotFound(new { message = "Usuario no encontrado" });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
    {
        command.UserId = id;
        var result = await _mediator.Send(command);
        if (result is null) return NotFound(new { message = "Usuario no encontrado para actualizar" });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteUserCommand { UserId = id });
        if (!success) return NotFound(new { message = "Usuario no encontrado para eliminar" });
        return Ok(new { message = "Usuario eliminado correctamente" });
    }
}