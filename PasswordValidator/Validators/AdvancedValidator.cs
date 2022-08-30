using PasswordValidator.Enums;
using PasswordValidator.Rules;

namespace PasswordValidator.Validators
{
    public class AdvancedValidator : IPasswordValidator
    {
        public ValidatorType ValidatorType => ValidatorType.Advanced;
        public IEnumerable<IRule> Rules { get; set; }

        public AdvancedValidator(IEnumerable<IRule> rules)
        {
            Rules = rules;
        }

        public bool Validate(string password)
        {
            bool isValidLength = (password.Length >= 10) && (password.Length <= 18);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));
            bool containsEnoughNumbers = password.Where(char.IsDigit).Count() >= 2;

            return isValidLength && containsSpecialCharacter && containsEnoughNumbers;
        }
    }
}
