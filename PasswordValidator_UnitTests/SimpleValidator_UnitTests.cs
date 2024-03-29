﻿using NUnit.Framework;
using PasswordValidator.Validators;
using System;

namespace PasswordValidator_UnitTests
{
    internal class SimpleValidator_UnitTests
    {
        private readonly IPasswordValidator _validator;

        public SimpleValidator_UnitTests()
        {
            _validator = new SimpleValidator();
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
        public void IsValidPassword_InvalidPassword_ShouldReturnFalse(string password)
        {
            var result = _validator.Validate(password);
            Assert.IsFalse(result);
        }

        [TestCase(null, Description = "Null")]
        [TestCase("", Description = "Empty String")]
        [TestCase(" ", Description = "Whitespace")]
        public void IsValidPassword_Null_ShouldThrowArgumentNullException(string advancedPassword)
        {
            var argumentException = Assert.Throws<ArgumentException>(() => _validator.Validate(advancedPassword));
            Assert.AreEqual("password cannot be null or whitespace", argumentException?.Message);
        }
    }
}
