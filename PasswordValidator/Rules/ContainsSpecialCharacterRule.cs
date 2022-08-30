namespace PasswordValidator.Rules
{
    public class ContainsSpecialCharacterRule : IRule
    {
        public bool Satisfied(string password)
        {
            return password.Any(character => !char.IsLetterOrDigit(character));
        }
    }
}
