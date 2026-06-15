using MediatR;

namespace EsleyterEduardoBA.Application.Features.Auth.Commands;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginResult>;

public record LoginResult(bool Success, string Message, string? Token);