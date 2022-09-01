using NUnit.Framework;
using NSubstitute;
using PasswordValidator.Rules;
using PasswordValidator.Validators;
using System;
using PasswordValidator.Enums;
using System.Collections.Generic;

namespace PasswordValidator_UnitTests
{
    internal class AdvancedValidator_UnitTests
    {
        private IPasswordValidator? _validator;
        private readonly IRule _mockLengthRule;
        private readonly IRule _mockNumberRule;
        private readonly IRule _mockCharacterRule;


        public AdvancedValidator_UnitTests()
        {
            _mockLengthRule = Substitute.For<IRule>();
            _mockNumberRule = Substitute.For<IRule>();
            _mockCharacterRule = Substitute.For<IRule>();

            _mockLengthRule.Type.Returns(RuleType.AdvancedLength);
            _mockNumberRule.Type.Returns(RuleType.AdvancedNumber);
            _mockCharacterRule.Type.Returns(RuleType.ContainsSpecialCharacter);
        }

        [Test]
        public void IsValidAdvancedPassword_AllRulesSatisfied_ShouldReturnTrue()
        {
            _mockLengthRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockNumberRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(true);

            var mockRules = new IRule[] { _mockLengthRule, _mockNumberRule, _mockCharacterRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsTrue(result);
        }

        [TestCase(false, true, true)]
        [TestCase(true, false, true)]
        [TestCase(true, true, false)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void IsValidAdvancedPassword_AtLeastOneRuleReturnsFalse_ShouldReturnFalse(bool lengthRule, bool numberRule, bool characterRule)
        {
            _mockLengthRule.Satisfied(Arg.Any<string>()).Returns(lengthRule);
            _mockNumberRule.Satisfied(Arg.Any<string>()).Returns(numberRule);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(characterRule);

            var mockRules = new IRule[] { _mockLengthRule, _mockNumberRule, _mockCharacterRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");
            Assert.IsFalse(result);
        }
    }
}
