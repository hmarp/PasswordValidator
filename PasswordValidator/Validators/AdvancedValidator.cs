using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public class AdvancedValidator : IPasswordValidator
    {
        public ValidatorType ValidatorType => ValidatorType.Advanced;

        public bool Validate(string password)
        {
            bool isValidLength = (password.Length >= 10) && (password.Length <= 18);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));
            bool containsEnoughNumbers = password.Where(char.IsDigit).Count() >= 2;

            return isValidLength && containsSpecialCharacter && containsEnoughNumbers;
        }
    }
}
