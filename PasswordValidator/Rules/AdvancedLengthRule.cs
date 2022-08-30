using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class AdvancedLengthRule : IRule
    {
        public bool Satisfied(string password)
        {
            return (password.Length >= 10) && (password.Length <= 18);
        }
    }
}
