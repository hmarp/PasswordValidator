﻿using NUnit.Framework;
using PasswordValidator;


namespace PasswordValidator_UnitTests
{
    internal class AdvancedValidator_UnitTests
    {
        AdvancedValidator _validator = new AdvancedValidator();

        [TestCase("aieinr343_3@")]
        [TestCase("111dfjiea@e3")]
        [TestCase("3jda;af4fdaffede4")]
        public void IsValidAdvancedPassword_ValidPassword_ShouldReturnTrue(string advancedPassword)
        {
            bool result = _validator.Validate(advancedPassword);

            Assert.IsTrue(result);
        }

        [TestCase("eifn-fhje@ee33flren", Description = "Too Long")]
        [TestCase("22@rekfev", Description = "Too Short")]
        [TestCase("1jie@rneff", Description = "Not Enough Numbers")]
        [TestCase("2300fmnenvieu", Description = "No Special Character")]
        public void IsValidAdvancedPassword_InvalidPassword_ShouldReturnFalse(string advancedPassword)
        {
            bool result = _validator.Validate(advancedPassword);

            Assert.IsFalse(result);
        }
    }
}
