using System;
using NUnit.Framework;
using PasswordValidator.Rules;

namespace PasswordValidator_UnitTests.Rule_Tests
{
    public class SimpleNumberRule_UnitTests
    {
        private readonly IRule _rule;

        public SimpleNumberRule_UnitTests()
        {
            _rule = new SimpleNumberRule();
        }

        [TestCase("1")]
        [TestCase("94584")]
        [TestCase("anklcvak3akdfl")]
        [TestCase("[[][3423424[][")]
        [TestCase("10001110101")]
        [TestCase("afk-2-=")]
        public void Satisfied_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsTrue(result);
        }

        [TestCase("jafneivhv")]
        [TestCase("fmv:[]a")]
        [TestCase("::@@{{Q}V}C")]
        [TestCase("?>?>{}~@!")]
        public void Satisfied_InvalidPassword_ShouldReturnFalse(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsFalse(result);
        }

        public void Satisfied_NullPassword_ShouldThrowArgumetNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _rule.Satisfied(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'password')", ex?.Message);
        }
    }
}
