namespace PasswordValidator
{
    public abstract class PasswordValidatorCreator
    {
        public abstract IPasswordValidator CreateValidator();
    }

    public class SimpleValidatorFactory : PasswordValidatorCreator
    {
        public override IPasswordValidator CreateValidator()
        {
            return new SimpleValidator();
        }
    }

    public class AdvancedValidatorFactory : PasswordValidatorCreator
    {
        public override IPasswordValidator CreateValidator()
        {
            return new AdvancedValidator();
        }
    }
}
