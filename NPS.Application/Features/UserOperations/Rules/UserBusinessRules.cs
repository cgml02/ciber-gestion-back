using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using System.Security.Cryptography;

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

    public string HashPassword(string password)
    {
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        string base64Hash = Convert.ToBase64String(hashBytes);
        return base64Hash;
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        for (int i = 0; i < 20; i++)
        {
            if (hashBytes[i + 16] != hash[i])
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }
        }
        return true; // Las contraseñas coinciden
    }
}