using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class AdvancedNumberRule : IRule
    {
        public RuleType Type => RuleType.AdvancedNumber;

        public bool Satisfied(string password)
        {
            return password.Where(char.IsDigit).Count() >= 2;
        }
    }
}
