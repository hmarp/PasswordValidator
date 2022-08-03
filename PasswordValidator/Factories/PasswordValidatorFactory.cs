using PasswordValidator.Enums;
using PasswordValidator.Validators;

namespace PasswordValidator.Factories
{
    public class PasswordValidatorFactory : IValidatorFactory
    {
        private readonly IDictionary<string, IPasswordValidator> _validators;

        public PasswordValidatorFactory()
        {
            _validators = new Dictionary<string, IPasswordValidator>();
            _validators.Add(ValidatorType.simple.ToString(), new SimpleValidator());
            _validators.Add(ValidatorType.advanced.ToString(), new AdvancedValidator());
        }

        public IPasswordValidator GetPasswordValidator(ValidatorType validatorType)
        {
            return _validators[validatorType.ToString()];
        }
    }
}
