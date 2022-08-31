using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class SimpleLengthRule : IRule
    {
        public RuleType Type  => RuleType.SimpleLength;

        public bool Satisfied(string password)
        {
            return (password.Length >= 6) && (password.Length <= 12);
        }
    }
}
