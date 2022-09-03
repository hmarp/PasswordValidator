using System;
using NUnit.Framework;
using PasswordValidator.Rules;

namespace PasswordValidator_UnitTests.Rule_Tests
{
    public class ContainsSpecialCharacterRule_UnitTests
    {
        private readonly IRule _rule;

        public ContainsSpecialCharacterRule_UnitTests()
        {
            _rule = new ContainsSpecialCharacterRule();
        }

        [TestCase("v57-rv8")]
        [TestCase("guv643@@7x")]
        [TestCase("n8{n9/0n6v")]
        [TestCase("bnb<vcd34rd")]
        [TestCase("huhui7~d4s")]
        [TestCase("344#5#t#yfvjk8")]
        [TestCase("u90``ug56")]
        [TestCase("jhcrt.\\g4")]
        public void Satisfied_ValidPassword_ShouldReturnTrue(string password)
        {
            var result = _rule.Satisfied(password);
            Assert.IsTrue(result);
        }

        [TestCase("gfsj4hj3")]
        [TestCase("ava343a")]
        [TestCase("432432")]
        [TestCase("gda3223")]
        [TestCase("afac3221")]
        [TestCase("ggggggg")]
        [TestCase("")]
        public void Satisfied_InvalidPassword_ShoudlReturnFalse(string password)
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
