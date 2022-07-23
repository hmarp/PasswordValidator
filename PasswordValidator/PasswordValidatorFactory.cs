namespace PasswordValidator
{
    public interface IValidatorFactory
    {
        public IPasswordValidator GetPasswordValidator(string validatorType);
    }

    public class PasswordValidatorFactory : IValidatorFactory
    {
        public IPasswordValidator GetPasswordValidator(string validatorType)
        {
            if (validatorType == "Simple")
            {
                return new SimpleValidator();
            }
            else
            {
                return new AdvancedValidator();
            }
        }
    }
}
