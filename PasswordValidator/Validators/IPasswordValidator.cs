namespace PasswordValidator.Validators
{
    public interface IPasswordValidator
    {
        public bool Validate(string password);
    }
}
