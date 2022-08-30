namespace PasswordValidator.Rules
{
    public class SimpleLengthRule : IRule
    {
        public bool Satisfied(string password)
        {
            return (password.Length >= 6) && (password.Length <= 12);
        }
    }
}
