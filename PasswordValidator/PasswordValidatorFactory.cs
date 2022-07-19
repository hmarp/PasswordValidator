namespace PasswordValidator
{
    public class ValidatorFactory
    {
        public IPasswordValidator GetValidator(string validatorType)
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
