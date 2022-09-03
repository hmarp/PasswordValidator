using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class AdvancedNumberRule : IRule
    {
        public RuleType Type => RuleType.AdvancedNumber;

        public bool Satisfied(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            return password.Where(char.IsDigit).Count() >= 2;
        }
    }
}
