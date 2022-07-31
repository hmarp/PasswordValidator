namespace PasswordValidator
{
    public class SimpleValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            bool isValidLength = (password.Length >= 6) && (password.Length <= 12);
            bool containsNumber = password.Any(char.IsDigit);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

            return isValidLength && containsNumber && containsSpecialCharacter;
        }
    }
}
