namespace PasswordValidator
{
    public static class Validator
    {
        public static bool IsValidPassword(string password)
        {
            bool isValidLength = (password.Length >= 6) && (password.Length <= 12);
            bool containsNumber = password.Any(char.IsDigit);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

            return isValidLength && containsNumber && containsSpecialCharacter;
        }

        public static bool isValidAdvancedPassword(string password)
        {
            bool isValidLength = (password.Length >= 10) && (password.Length <= 18);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));
            bool containsEnoughNumbers = password.Where(char.IsDigit).Count() >= 2;

            return isValidLength && containsSpecialCharacter && containsEnoughNumbers;
        }
    }
}
