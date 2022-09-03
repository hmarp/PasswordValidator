using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class AdvancedLengthRule : IRule
    {
        public RuleType Type => RuleType.AdvancedLength;

        public bool Satisfied(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            return (password.Length >= 10) && (password.Length <= 18);
        }
    }
}
