namespace PasswordValidator
{
    public class AdvancedValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            bool isValidLength = (password.Length >= 10) && (password.Length <= 18);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));
            bool containsEnoughNumbers = password.Where(char.IsDigit).Count() >= 2;

            return isValidLength && containsSpecialCharacter && containsEnoughNumbers;
        }
    }
}
