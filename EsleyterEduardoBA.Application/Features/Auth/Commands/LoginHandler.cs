using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Domain.Ports.Services;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Auth.Commands;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public LoginHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
            return new LoginResult(false, "Credenciales inválidas.", null);

        var isValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
        if (!isValid)
            return new LoginResult(false, "Credenciales inválidas.", null);

        var roles = await _userRepository.GetRolesAsync(user);
        var token = _jwtService.GenerateToken(user, roles);

        return new LoginResult(true, "Login exitoso.", token);
    }
}