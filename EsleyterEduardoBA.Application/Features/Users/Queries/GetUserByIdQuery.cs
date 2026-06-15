using EsleyterEduardoBA.Domain.DTOs;
using EsleyterEduardoBA.Domain.Ports.Repository;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public int UserId { get; set; }
}

internal sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user is null) return null;

        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email
        };
    }
}