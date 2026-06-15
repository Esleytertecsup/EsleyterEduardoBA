using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Roles.Commands;

public class UpdateRoleCommand : IRequest<RoleDto?>
{
    public int RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
}

internal sealed class UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateRoleCommand, RoleDto?>
{
    public async Task<RoleDto?> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetByIdAsync(request.RoleId);
        if (role is null) return null;

        role.Name = request.Name;
        unitOfWork.Roles.Update(role);
        await unitOfWork.SaveChangesAsync();

        return new RoleDto { RoleId = role.RoleId, Name = role.Name };
    }
}