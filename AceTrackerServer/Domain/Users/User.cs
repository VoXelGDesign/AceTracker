using Domain.Shared.Enums;

namespace Domain.User;

public class User
{
    public UserId UserId { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public UserPassword UserPassword { get; private set; } = null!;
    public Role Role { get; private set; } = Role.User;

    public static User? Create(string Name, UserPassword password)
    => new User
    {
        UserId = new UserId(Guid.NewGuid()),
        Name = Name,
        UserPassword = password,
    };

    public void GrandAdminRole()
    {
        Role = Role.Admin;
    }
}
