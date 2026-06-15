using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Roles.Commands;

public class DeleteRoleCommand : IRequest<bool>
{
    public int RoleId { get; set; }
}

internal sealed class DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteRoleCommand, bool>
{
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetByIdAsync(request.RoleId);
        if (role is null) return false;

        unitOfWork.Roles.Delete(role);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}