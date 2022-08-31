using NUnit.Framework;
using PasswordValidator.Rules;
using PasswordValidator.Validators;
using System;
using System.Collections.Generic;

namespace PasswordValidator_UnitTests
{
    internal class SimpleValidator_UnitTests
    {
        private readonly IPasswordValidator _validator;

        public SimpleValidator_UnitTests()
        {
            var rules = new List<IRule>
            {
                new SimpleLengthRule(),
                new SimpleNumberRule(),
                new ContainsSpecialCharacterRule()
            };

            _validator = new SimpleValidator(rules);
        }

        [TestCase("0erknn3#1")]
        [TestCase("@fjeiapfio3")]
        [TestCase("fdnke4442-2")]
        [TestCase("eibn3j22if';")]
        [TestCase("10fign9w-=w")]
        [TestCase("===111kkkff")]
        [TestCase("dfa;n2niv")]
        public void Validate_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _validator.Validate(password);
            Assert.IsTrue(result);
        }

        [TestCase("fnekafjnkle3243-a{", Description = "Too Long")]
        [TestCase("fa#3", Description = "Too Short")]
        [TestCase("feafee@@ae", Description = "Does Not Contain Number")]
        [TestCase("nfn2232ier", Description = "Does Not Contain Special Character")]
        [TestCase("", Description = "Emtpy String")]
        [TestCase(" ", Description = "Whitespace")]
        public void IsValidPassword_InvalidPassword_ShouldReturnFalse(string password)
        {
            var result = _validator.Validate(password);
            Assert.IsFalse(result);
        }

        [TestCase(null, Description = "Null")]
        public void IsValidPassword_Null_ShouldThrowNullReferenceException(string advancedPassword)
        {
            Assert.Throws<NullReferenceException>(() => _validator.Validate(advancedPassword));
        }
    }
}
