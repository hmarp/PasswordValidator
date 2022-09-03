using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class SimpleNumberRule : IRule
    {
        public RuleType Type => RuleType.SimpleNumber;

        public bool Satisfied(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            return password.Any(char.IsDigit);
        }
    }
}
