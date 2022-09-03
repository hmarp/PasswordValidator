using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public class ContainsSpecialCharacterRule : IRule
    {
        public RuleType Type => RuleType.ContainsSpecialCharacter;

        public bool Satisfied(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            return password.Any(character => !char.IsLetterOrDigit(character));
        }
    }
}
