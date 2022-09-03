using NUnit.Framework;
using NSubstitute;
using PasswordValidator.Rules;
using PasswordValidator.Validators;
using PasswordValidator.Enums;
using System;
using System.Collections.Generic;

namespace PasswordValidator_UnitTests
{
    internal class AdvancedValidator_UnitTests
    {
        private IPasswordValidator? _validator;
        private readonly IRule _mockSimpleLengthRule;
        private readonly IRule _mockSimpleNumberRule;
        private readonly IRule _mockAdvancedLengthRule;
        private readonly IRule _mockAdvancedNumberRule;
        private readonly IRule _mockCharacterRule;


        public AdvancedValidator_UnitTests()
        {
            _mockCharacterRule = Substitute.For<IRule>();
            _mockSimpleLengthRule = Substitute.For<IRule>();
            _mockSimpleNumberRule = Substitute.For<IRule>();
            _mockAdvancedNumberRule = Substitute.For<IRule>();
            _mockAdvancedLengthRule = Substitute.For<IRule>();

            _mockCharacterRule.Type.Returns(RuleType.ContainsSpecialCharacter);
            _mockSimpleLengthRule.Type.Returns(RuleType.SimpleLength);
            _mockSimpleNumberRule.Type.Returns(RuleType.SimpleNumber);
            _mockAdvancedLengthRule.Type.Returns(RuleType.AdvancedLength);
            _mockAdvancedNumberRule.Type.Returns(RuleType.AdvancedNumber);
        }

        [TearDown]
        public void CleanUp()
        {
            _mockCharacterRule.ClearReceivedCalls();
            _mockSimpleLengthRule.ClearReceivedCalls();
            _mockSimpleNumberRule.ClearReceivedCalls();
            _mockAdvancedLengthRule.ClearReceivedCalls();
            _mockAdvancedNumberRule.ClearReceivedCalls();
        }

        [Test]
        public void Validate_AllRulesSatisfied_ShouldReturnTrue()
        {
            _mockAdvancedLengthRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockAdvancedNumberRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(true);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsTrue(result);
            _mockAdvancedLengthRule.Received().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.Received().Satisfied(Arg.Any<string>());
            _mockCharacterRule.Received().Satisfied(Arg.Any<string>());
            _mockSimpleNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_AdvancedLengthRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockAdvancedLengthRule.Satisfied(Arg.Any<string>()).Returns(false);
            _mockAdvancedNumberRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(true);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);
            _mockAdvancedLengthRule.Received().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockCharacterRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_AdvancedNumberRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockAdvancedLengthRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockAdvancedNumberRule.Satisfied(Arg.Any<string>()).Returns(false);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(true);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);
            _mockAdvancedLengthRule.Received().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.Received().Satisfied(Arg.Any<string>());
            _mockCharacterRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_CharacterRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockAdvancedLengthRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockAdvancedNumberRule.Satisfied(Arg.Any<string>()).Returns(true);
            _mockCharacterRule.Satisfied(Arg.Any<string>()).Returns(false);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new AdvancedValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);
            _mockAdvancedLengthRule.Received().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.Received().Satisfied(Arg.Any<string>());
            _mockCharacterRule.Received().Satisfied(Arg.Any<string>());
            _mockSimpleNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockSimpleLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }
        
        [TestCase(false, true, false, "AdvancedLength")]
        [TestCase(false, false, false, "AdvancedLength")]
        [TestCase(false, true, true, "AdvancedLength")]
        [TestCase(true, false, false, "AdvancedNumber")]
        [TestCase(true, false, true, "AdvancedNumber")]
        [TestCase(true, true, false, "ContainsSpecialCharacter")]
        public void CreateAdvancedValidator_InvalidRulesCollection_ShouldThrowArgumentException(bool containsLengthRule, bool containsNumberRule, bool containsCharacterRule, string exceptionRuleName)
        {
            var mockRules = new List<IRule>();
            if (containsLengthRule) mockRules.Add(_mockAdvancedLengthRule);
            if (containsNumberRule) mockRules.Add(_mockAdvancedNumberRule);
            if (containsCharacterRule) mockRules.Add(_mockCharacterRule);

            var ex = Assert.Throws<ArgumentException>(() => new AdvancedValidator(mockRules));
            Assert.AreEqual($"Rule of Type {exceptionRuleName} missing", ex?.Message);
        }

        [Test]
        public void CreateAdvancedValidator_NullRulesCollection_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AdvancedValidator(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'rules')", ex?.Message);
        }
    }
}
