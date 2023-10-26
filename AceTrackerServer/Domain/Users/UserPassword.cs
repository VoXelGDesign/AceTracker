using Domain.Users.Properties;
using Microsoft.AspNet.Identity;

namespace Domain.Users;

public record UserPassword
{
    public string HashedPassword { get; set; }

    private UserPassword(string hashedPassword)
    {
        HashedPassword = hashedPassword;
    }

    public static UserPassword? Create(string password, IPasswordHasher passwordHasher)
    {
        if (!UserValidationProperties.UserPasswordRegex().IsMatch(password)) return null;

        var hashedPassword = passwordHasher.HashPassword(password);

        return new UserPassword(hashedPassword);
    }

    public static UserPassword? FromHashedPassword(string hashedPassword)
    {
        if (hashedPassword is null) return null;

        return new UserPassword(hashedPassword);
    }

}


