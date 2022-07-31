namespace PasswordValidator.Factories
{
    public interface IValidatorFactory
    {
        public IPasswordValidator GetPasswordValidator(string validatorType);
    }
}
