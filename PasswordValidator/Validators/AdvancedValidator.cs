﻿using PasswordValidator.Enums;
using PasswordValidator.Rules;

namespace PasswordValidator.Validators
{
    public class AdvancedValidator : BaseValidator, IPasswordValidator
    {
        public new ValidatorType ValidatorType => ValidatorType.Advanced;

        public AdvancedValidator(IEnumerable<IRule> rules)
        {
            if (rules == null) throw new ArgumentNullException(nameof(rules));

            var lengthRule = rules.Where(rule => rule.Type == RuleType.AdvancedLength).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.AdvancedLength.ToString()} missing");
            var numberRule = rules.Where(rule => rule.Type == RuleType.AdvancedNumber).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.AdvancedNumber.ToString()} missing");
            var specialCharacterRule = rules.Where(rule => rule.Type == RuleType.ContainsSpecialCharacter).FirstOrDefault() ?? throw new ArgumentException($"Rule of Type {RuleType.ContainsSpecialCharacter.ToString()} missing");
        
            base.Rules = new IRule[] { lengthRule, numberRule, specialCharacterRule };
        }
    }
}
