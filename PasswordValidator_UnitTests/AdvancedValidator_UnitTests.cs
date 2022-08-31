using NUnit.Framework;
using PasswordValidator.Rules;
using PasswordValidator.Validators;
using System;
using System.Collections.Generic;

namespace PasswordValidator_UnitTests
{
    internal class AdvancedValidator_UnitTests
    {
        private readonly IPasswordValidator _validator;

        public AdvancedValidator_UnitTests()
        {
            var rules = new List<IRule>
            {
                new AdvancedLengthRule(),
                new AdvancedNumberRule(),
                new ContainsSpecialCharacterRule()
            };

            _validator = new AdvancedValidator(rules);
        }

        [TestCase("aieinr343_3@")]
        [TestCase("111dfjiea@e3")]
        [TestCase("3jda;af4fdaffede4")]
        [TestCase("qqqwww333@@@")]
        [TestCase("f92-v;w/2wqfas")]
        [TestCase("29fjvie[w'fwfk")]
        public void IsValidAdvancedPassword_ValidPassword_ShouldReturnTrue(string advancedPassword)
        {
            var result = _validator.Validate(advancedPassword);
            Assert.IsTrue(result);
        }

        [TestCase("eifn-fhje@ee33flren", Description = "Too Long")]
        [TestCase("22@rekfev", Description = "Too Short")]
        [TestCase("1jie@rneff", Description = "Not Enough Numbers")]
        [TestCase("2300fmnenvieu", Description = "No Special Character")]
        [TestCase("justaword")]
        [TestCase("", Description = "Emtpy String")]
        [TestCase(" ", Description = "Whitespace")]
        public void IsValidAdvancedPassword_InvalidPassword_ShouldReturnFalse(string advancedPassword)
        {
            var result = _validator.Validate(advancedPassword);
            Assert.IsFalse(result);
        }

        [TestCase(null, Description = "Null")]
        public void IsValidAdvancedPassword_Null_ShouldThrowNullReferenceException(string advancedPassword)
        {
            Assert.Throws<NullReferenceException>(() => _validator.Validate(advancedPassword));
        }
    }
}
