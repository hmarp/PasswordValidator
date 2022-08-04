using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public interface IPasswordValidator
    {
        public ValidatorType ValidatorType { get; }
        public bool Validate(string password);
    }
}
