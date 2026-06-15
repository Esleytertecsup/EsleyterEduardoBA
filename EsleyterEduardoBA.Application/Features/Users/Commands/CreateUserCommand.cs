using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Domain.Ports.Services;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Users.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

internal sealed class CreateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher)
    : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new Domain.Entities.User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHasher.HashPassword("Tecsup2026!")
        };

        await unitOfWork.Users.AddAsync(newUser);
        await unitOfWork.SaveChangesAsync();

        return new UserDto
        {
            UserId = newUser.UserId,
            Username = newUser.Username,
            Email = newUser.Email
        };
    }
}