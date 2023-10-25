using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    
        public record UserPassword
        {
            public string Password { get; set; }
            public string HashedPassword { get; set; }

            public UserPassword(string password, string hashedPassword)
            {
                Password = password;
                HashedPassword = hashedPassword;
            }
        
            private static readonly Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", RegexOptions.Compiled);

            public static UserPassword? Create(string password, IPasswordHasher passwordHasher)
            {
                if (!PasswordRegex.IsMatch(password))
                {
                    return null;
                }

                var hashedPassword = passwordHasher.HashPassword(password);
                return new UserPassword(password, hashedPassword);
            }
        }
    
}
