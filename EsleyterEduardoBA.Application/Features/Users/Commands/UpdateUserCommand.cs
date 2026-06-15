using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<UserDto?>
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

internal sealed class UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateUserCommand, UserDto?>
{
    public async Task<UserDto?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user is null) return null;

        user.Username = request.Username;
        user.Email = request.Email;

        unitOfWork.Users.Update(user);
        await unitOfWork.SaveChangesAsync();

        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email
        };
    }
}