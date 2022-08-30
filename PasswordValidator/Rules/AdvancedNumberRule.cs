namespace PasswordValidator.Rules
{
    public class AdvancedNumberRule : IRule
    {
        public bool Satisfied(string password)
        {
            return password.Where(char.IsDigit).Count() >= 2;
        }
    }
}
