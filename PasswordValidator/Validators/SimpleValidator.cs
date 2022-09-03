using PasswordValidator.Enums;
using PasswordValidator.Rules;

namespace PasswordValidator.Validators
{
    public class SimpleValidator : BaseValidator, IPasswordValidator
    {
        public new ValidatorType ValidatorType => ValidatorType.Simple;

        public SimpleValidator(IEnumerable<IRule> rules)
        {
            if (rules == null) throw new ArgumentNullException(nameof(rules));

            var lengthRule = rules.Where(rule => rule.Type == RuleType.SimpleLength).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleLength.ToString()} missing");
            var numberRule = rules.Where(rule => rule.Type == RuleType.SimpleNumber).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleNumber.ToString()} missing");
            var specialCharacterRule = rules.Where(rule => rule.Type == RuleType.ContainsSpecialCharacter).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.ContainsSpecialCharacter.ToString()} missing");

            base.Rules = new IRule[] { lengthRule, numberRule, specialCharacterRule };
        }
    }
}
