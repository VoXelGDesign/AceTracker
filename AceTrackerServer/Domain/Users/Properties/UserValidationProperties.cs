using System.Text.RegularExpressions;

namespace Domain.Users.Properties;
public static class UserValidationProperties
{
    private const int _userNameMaxLenght = 255;
    private static readonly Regex _userPasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", RegexOptions.Compiled);

    public static int UserNameMaxLenght()
        => _userNameMaxLenght;
    public static Regex UserPasswordRegex()
        => _userPasswordRegex;
}
