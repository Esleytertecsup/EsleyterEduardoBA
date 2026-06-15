using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Users.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public int UserId { get; set; }
}

internal sealed class DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user is null) return false;

        unitOfWork.Users.Delete(user);
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}