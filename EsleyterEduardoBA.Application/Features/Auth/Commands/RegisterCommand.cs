using MediatR;

namespace EsleyterEduardoBA.Application.Features.Auth.Commands;

public record RegisterCommand(
    string Username,
    string Email,
    string Password
) : IRequest<RegisterResult>;

public record RegisterResult(bool Success, string Message);