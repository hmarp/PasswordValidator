using PasswordValidator.Enums;
using PasswordValidator.Rules;

namespace PasswordValidator.Validators
{
    public class SimpleValidator : BaseValidator, IPasswordValidator
    {
        public new ValidatorType ValidatorType => ValidatorType.Simple;

        public SimpleValidator(IEnumerable<IRule> rules)
        {
            var lengthRule = rules.Where(rule => rule.Type == RuleType.SimpleLength).First() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleNumber.ToString()} missing");
            var numberRule = rules.Where(rule => rule.Type == RuleType.SimpleNumber).First() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleNumber.ToString()} missing");
            var specialCharacterRule = rules.Where(rule => rule.Type == RuleType.ContainsSpecialCharacter).First() ?? throw new ArgumentException($"{RuleType.ContainsSpecialCharacter.ToString()}");

            base.Rules = new IRule[] { lengthRule, numberRule, specialCharacterRule };
        }
    }
}
