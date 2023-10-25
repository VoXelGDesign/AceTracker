using Domain.Users.Properties;

namespace Domain.Users;
public record UserName
{
    public string Name { get; private set; } = null!;

    public static UserName? Create(string name)
    {
        if (name.Length > UserValidationProperties.UserNameMaxLenght()) return null;

        return new UserName
        {
            Name = name
        };
    }
}