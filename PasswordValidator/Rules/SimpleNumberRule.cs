namespace PasswordValidator.Rules
{
    public class SimpleNumberRule : IRule
    {
        public bool Satisfied(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
