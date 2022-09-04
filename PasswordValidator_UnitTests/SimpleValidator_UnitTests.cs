using NSubstitute;
using NUnit.Framework;
using PasswordValidator.Enums;
using PasswordValidator.Rules;
using PasswordValidator.Validators;
using System;
using System.Collections.Generic;

namespace PasswordValidator_UnitTests
{
    internal class SimpleValidator_UnitTests
    {
        private readonly string _password;
        private IPasswordValidator? _validator;

        private readonly IRule _mockSimpleLengthRule;
        private readonly IRule _mockSimpleNumberRule;
        private readonly IRule _mockAdvancedLengthRule;
        private readonly IRule _mockAdvancedNumberRule;
        private readonly IRule _mockCharacterRule;

        public SimpleValidator_UnitTests()
        {
            _password = "testPassword";

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
            _mockSimpleLengthRule.Satisfied(_password).Returns(true);
            _mockSimpleNumberRule.Satisfied(_password).Returns(true);
            _mockCharacterRule.Satisfied(_password).Returns(true);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new SimpleValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsTrue(result);

            _mockSimpleNumberRule.Received().Satisfied(_password);
            _mockSimpleLengthRule.Received().Satisfied(_password);
            _mockCharacterRule.Received().Satisfied(_password);
            _mockAdvancedLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_SimpleLengthRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockSimpleLengthRule.Satisfied(_password).Returns(false);
            _mockSimpleNumberRule.Satisfied(_password).Returns(true);
            _mockCharacterRule.Satisfied(_password).Returns(true);

            var mockRules = new IRule[] { _mockSimpleLengthRule, _mockSimpleNumberRule, _mockCharacterRule, _mockAdvancedLengthRule, _mockAdvancedNumberRule };
            _validator = new SimpleValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);

            _mockSimpleLengthRule.Received().Satisfied(_password);
            _mockSimpleNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockCharacterRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_SimpleNumberRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockSimpleLengthRule.Satisfied(_password).Returns(true);
            _mockSimpleNumberRule.Satisfied(_password).Returns(false);
            _mockCharacterRule.Satisfied(_password).Returns(true);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new SimpleValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);

            _mockSimpleLengthRule.Received().Satisfied(_password);
            _mockSimpleNumberRule.Received().Satisfied(_password);
            _mockCharacterRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [Test]
        public void Validate_CharacterRuleNotSatisfied_ShouldReturnFalse()
        {
            _mockSimpleLengthRule.Satisfied(_password).Returns(true);
            _mockSimpleNumberRule.Satisfied(_password).Returns(true);
            _mockCharacterRule.Satisfied(_password).Returns(false);

            var mockRules = new IRule[] { _mockAdvancedLengthRule, _mockAdvancedNumberRule, _mockCharacterRule, _mockSimpleLengthRule, _mockSimpleNumberRule };
            _validator = new SimpleValidator(mockRules);

            var result = _validator.Validate("testPassword");

            Assert.IsFalse(result);

            _mockSimpleNumberRule.Received().Satisfied(_password);
            _mockSimpleLengthRule.Received().Satisfied(_password);
            _mockCharacterRule.Received().Satisfied(_password);
            _mockAdvancedLengthRule.DidNotReceive().Satisfied(Arg.Any<string>());
            _mockAdvancedNumberRule.DidNotReceive().Satisfied(Arg.Any<string>());
        }

        [TestCase(false, true, false, "SimpleLength")]
        [TestCase(false, false, false, "SimpleLength")]
        [TestCase(false, true, true, "SimpleLength")]
        [TestCase(true, false, false, "SimpleNumber")]
        [TestCase(true, false, true, "SimpleNumber")]
        [TestCase(true, true, false, "ContainsSpecialCharacter")]
        public void CreateSimpleValidator_InvalidRulesCollection_ShouldThrowArgumentException(bool containsLengthRule, bool containsNumberRule, bool containsCharacterRule, string exceptionRuleName)
        {
            var mockRules = new List<IRule>();
            if (containsLengthRule) mockRules.Add(_mockSimpleLengthRule);
            if (containsNumberRule) mockRules.Add(_mockSimpleNumberRule);
            if (containsCharacterRule) mockRules.Add(_mockCharacterRule);

            var ex = Assert.Throws<ArgumentException>(() => new SimpleValidator(mockRules));
            Assert.AreEqual($"Rule of Type {exceptionRuleName} missing", ex?.Message);
        }

        [Test]
        public void CreateSimpleValidator_NullRulesCollection_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new SimpleValidator(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'rules')", ex?.Message);
        }
    }
}
