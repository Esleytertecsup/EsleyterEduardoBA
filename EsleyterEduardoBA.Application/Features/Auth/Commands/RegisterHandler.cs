using EsleyterEduardoBA.Domain.Entities;
using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Domain.Ports.Services;
using MediatR;

namespace EsleyterEduardoBA.Application.Features.Auth.Commands;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser is not null)
            return new RegisterResult(false, "El email ya está registrado.");

        var role = await _roleRepository.GetByNameAsync("User");
        if (role is null)
        {
            role = new Role { Name = "User" };
            await _roleRepository.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            Roles = new List<Role> { role }
        };

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new RegisterResult(true, "Usuario registrado exitosamente.");
    }
}