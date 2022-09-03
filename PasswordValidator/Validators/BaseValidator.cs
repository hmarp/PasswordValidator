using PasswordValidator.Rules;
using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public class BaseValidator : IPasswordValidator
    {
        public IEnumerable<IRule>? Rules;
        public ValidatorType ValidatorType => ValidatorType.Base;

        public bool Validate(string password)
        {
            if (Rules == null) return true;

            foreach (var rule in Rules)
            {
                if (!rule.Satisfied(password))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
