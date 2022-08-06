using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public class AdvancedValidator : IPasswordValidator
    {
        public ValidatorType ValidatorType => ValidatorType.Advanced;

        public bool Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Invlaid Null or Whitespace Password Input");
            }

            bool isValidLength = (password.Length >= 10) && (password.Length <= 18);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));
            bool containsEnoughNumbers = password.Where(char.IsDigit).Count() >= 2;

            return isValidLength && containsSpecialCharacter && containsEnoughNumbers;
        }
    }
}
