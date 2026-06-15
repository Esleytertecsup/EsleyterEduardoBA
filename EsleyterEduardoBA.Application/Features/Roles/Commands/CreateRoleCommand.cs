using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Roles.Commands;

public class CreateRoleCommand : IRequest<RoleDto>
{
    public string Name { get; set; } = string.Empty;
}

internal sealed class CreateRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateRoleCommand, RoleDto>
{
    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Domain.Entities.Role { Name = request.Name };

        await unitOfWork.Roles.AddAsync(role);
        await unitOfWork.SaveChangesAsync();

        return new RoleDto { RoleId = role.RoleId, Name = role.Name };
    }
}