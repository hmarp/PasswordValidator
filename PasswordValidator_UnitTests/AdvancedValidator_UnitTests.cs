using NUnit.Framework;
using PasswordValidator.Validators;
using System;

namespace PasswordValidator_UnitTests
{
    internal class AdvancedValidator_UnitTests
    {
        private readonly IPasswordValidator _validator;

        public AdvancedValidator_UnitTests()
        {
            _validator = new AdvancedValidator();
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
        public void IsValidAdvancedPassword_InvalidPassword_ShouldReturnFalse(string advancedPassword)
        {
            var result = _validator.Validate(advancedPassword);
            Assert.IsFalse(result);
        }

        [TestCase(null, Description = "Null")]
        [TestCase("", Description = "Empty String")]
        [TestCase(" ", Description = "Whitespace")]
        public void IsValidAdvancedPassword_InvalidInput_ShouldThrowArgumentNullException(string advancedPassword)
        {
            var argumentException = Assert.Throws<ArgumentException>(() => _validator.Validate(advancedPassword));
            Assert.AreEqual("password cannot be null or whitespace", argumentException?.Message);
        }
    }
}
