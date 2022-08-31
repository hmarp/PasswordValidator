using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class SimpleNumberRule : IRule
    {
        public RuleType Type => RuleType.SimpleNumber;

        public bool Satisfied(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
