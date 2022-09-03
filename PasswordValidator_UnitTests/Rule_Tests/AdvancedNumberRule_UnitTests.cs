using PasswordValidator.Rules;
using System;
using NUnit.Framework;

namespace PasswordValidator_UnitTests.Rule_Tests
{
    public class AdvancedNumberRule_UnitTests
    {
        private readonly IRule _rule;

        public AdvancedNumberRule_UnitTests()
        {
            _rule = new AdvancedNumberRule();
        }

        [TestCase("fieyur2infan2")]
        [TestCase("133")]
        [TestCase("11")]
        [TestCase("vasnk@39293[")]
        [TestCase("1[2]3[4]5")]
        [TestCase("2343928084329080")]
        public void Satisfied_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsTrue(result);
        }

        [TestCase("")]
        [TestCase("1")]
        [TestCase("auen9fna[]")]
        [TestCase("-{[1]}-")]
        [TestCase("9")]
        [TestCase("mv<0")]
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
