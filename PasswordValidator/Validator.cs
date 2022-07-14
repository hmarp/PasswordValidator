namespace PasswordValidator
{
    public static class Validator
    {
        public static bool IsValidPassword(string password)
        {
            bool isCorrectLength = (password.Length >= 6) && (password.Length <= 12);
            bool containsNumber = password.Any(char.IsDigit);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

            return isCorrectLength && containsNumber && containsSpecialCharacter;
        }
    }
}
