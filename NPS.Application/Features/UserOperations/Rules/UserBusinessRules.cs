using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;

namespace NPS.Application.Features.UserOperations.Rules;

public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
    {
        var result = await _userRepository.GetAsync(b => b.Email == email);

        if (result != null && result.Count > 0) throw new Exception("El email ya existe");
    }

    public void UserShouldExistWhenRequested(IReadOnlyList<UserEntity> user)
    {
        if (user == null) throw new Exception("Usuario o contraseña incorrectos");
        if (user.Count == 0) throw new Exception("Usuario o contraseña incorrectos");
    }
}