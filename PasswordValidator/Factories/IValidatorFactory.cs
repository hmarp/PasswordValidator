using PasswordValidator.Validators;
using PasswordValidator.Enums;

namespace PasswordValidator.Factories
{
    public interface IValidatorFactory
    {
        public IPasswordValidator GetPasswordValidator(ValidatorType validatorType);
    }
}
