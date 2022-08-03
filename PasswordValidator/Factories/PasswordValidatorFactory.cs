using PasswordValidator.Enums;
using PasswordValidator.Validators;

namespace PasswordValidator.Factories
{
    public class PasswordValidatorFactory : IValidatorFactory
    {
        private readonly IEnumerable<IPasswordValidator> _validators;

        public PasswordValidatorFactory(IEnumerable<IPasswordValidator> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public IPasswordValidator GetPasswordValidator(ValidatorType validatorType)
        {
            return _validators.Single(x => x.ValidatorType == validatorType);
        }
    }
}
