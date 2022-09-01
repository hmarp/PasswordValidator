using PasswordValidator.Rules;
using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public class BaseValidator : IPasswordValidator
    {
        private readonly IEnumerable<IRule> Rules;
        public ValidatorType ValidatorType => ValidatorType.Base;

        public BaseValidator(IEnumerable<IRule> rules)
        {
            Rules = rules;
        }

        public bool Validate(string password)
        {
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
