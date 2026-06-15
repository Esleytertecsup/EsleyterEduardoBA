using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Roles.Queries;

public class GetRoleByIdQuery : IRequest<RoleDto?>
{
    public int RoleId { get; set; }
}

internal sealed class GetRoleByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetByIdAsync(request.RoleId);
        if (role is null) return null;

        return new RoleDto { RoleId = role.RoleId, Name = role.Name };
    }
}