using System;
using NUnit.Framework;
using PasswordValidator.Rules;

namespace PasswordValidator_UnitTests.Rule_Tests
{
    public class SimpleLengthRule_UnitTests
    {
        private readonly IRule _rule;

        public SimpleLengthRule_UnitTests()
        {
            _rule = new SimpleLengthRule();
        }

        [TestCase("faebea")]
        [TestCase("qd3{ave")]
        [TestCase("mvj73[]-9cne")]
        [TestCase("fjf93478---")]
        [TestCase(">Alfjvie")]
        [TestCase("a908vjmlee")]
        [TestCase("afe3a34")]
        public void Satsified_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsTrue(result);
        }

        [TestCase("yf[2]")]
        [TestCase("vie83[d;~32fw")]
        [TestCase("23a")]
        [TestCase("fmv99082879738979v")]
        [TestCase("")]
        public void Satsified_InvalidPassword_ShouldReturnFalse(string password)
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
