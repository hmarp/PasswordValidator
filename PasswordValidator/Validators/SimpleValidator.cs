using PasswordValidator.Enums;
using PasswordValidator.Rules;

namespace PasswordValidator.Validators
{
    public class SimpleValidator : IPasswordValidator
    {
        public ValidatorType ValidatorType => ValidatorType.Simple;
        private readonly IEnumerable<IRule> Rules;

        public SimpleValidator(IEnumerable<IRule> rules)
        {
            var lengthRule = rules.Where(rule => rule.Type == RuleType.SimpleLength).First() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleNumber.ToString()} missing");
            var numberRule = rules.Where(rule => rule.Type == RuleType.SimpleNumber).First() ?? throw new ArgumentException($"Rule of Type {RuleType.SimpleNumber.ToString()} missing");
            var specialCharacterRule = rules.Where(rule => rule.Type == RuleType.ContainsSpecialCharacter).First() ?? throw new ArgumentException($"{RuleType.ContainsSpecialCharacter.ToString()}");

            Rules = new List<IRule> { lengthRule, numberRule, specialCharacterRule };
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
