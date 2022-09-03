using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class SimpleLengthRule : IRule
    {
        public RuleType Type  => RuleType.SimpleLength;

        public bool Satisfied(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            return (password.Length >= 6) && (password.Length <= 12);
        }
    }
}
