using PasswordValidator.Validators;

namespace PasswordValidator.Factories
{
    public class PasswordValidatorFactory : IValidatorFactory
    {
        private readonly IDictionary<string, IPasswordValidator> _validators;

        public PasswordValidatorFactory()
        {
            _validators = new Dictionary<string, IPasswordValidator>();
            _validators.Add("simple", new SimpleValidator());
            _validators.Add("advanced", new AdvancedValidator());
        }

        public IPasswordValidator GetPasswordValidator(string validatorType)
        {
            if (validatorType.ToLower() == "simple")
            {
                return _validators["simple"];
            }
            else if (validatorType.ToLower() == "advanced")
            {
                return _validators["advanced"];
            }
            else
            {
                throw new ArgumentException("Unrecognized validatorType");
            }
        }
    }
}
