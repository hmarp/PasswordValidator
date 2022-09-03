using NUnit.Framework;
using PasswordValidator.Rules;
using System;

namespace PasswordValidator_UnitTests.Rule_Tests
{
    public class AdvancedLengthRule_UnitTests
    {
        private readonly IRule _rule;

        public AdvancedLengthRule_UnitTests()
        {
            _rule = new AdvancedLengthRule();
        }

        [TestCase("fnri49-a93")]
        [TestCase("jvb94nf-a32")]
        [TestCase("urnv834-@3abr429vs")]
        [TestCase("8fajie03+fviofajf")]
        [TestCase("adfho;3909a8")]
        [TestCase("vn;akdfniejnkdf2")]
        public void Satisfied_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsTrue(result);
        }

        [TestCase("94uvnr@[2")]
        [TestCase("ediokvur8[]4/efgov,")]
        [TestCase("")]
        [TestCase("342fd")]
        [TestCase("fadjkbn339048321908908v908")]
        public void Satisfied_InvalidPassword_ShouldReturnFalse(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void Satisfied_NullPassword_ShouldThrowArgumetNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _rule.Satisfied(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'password')", ex?.Message);
        }
    }
}
