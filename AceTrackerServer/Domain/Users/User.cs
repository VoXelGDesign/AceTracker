using Domain.Shared.Enums;

namespace Domain.Users;

public class User
{
    public UserId UserId { get; private set; } = null!;
    public UserName UserName { get; private set; } = null!;
    public UserPassword UserPassword { get; private set; } = null!;
    public Role Role { get; private set; } = Role.User;

    public static User? Create(UserName name, UserPassword password)
        => new User
        {
            UserId = new UserId(Guid.NewGuid()),
            UserName = name,
            UserPassword = password,
        };

    public void GrandAdminRole()
    {
        Role = Role.Admin;
    }

    public void GrandUserRole()
    {
        Role = Role.User;
    }
}
