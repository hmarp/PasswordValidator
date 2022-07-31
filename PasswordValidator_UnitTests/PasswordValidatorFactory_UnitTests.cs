using PasswordValidator.Factories;
using PasswordValidator.Validators;
using NUnit.Framework;

namespace PasswordValidator_UnitTests
{
    internal class PasswordValidatorFactory_UnitTests
    {
        private readonly IValidatorFactory _validatorFactory;

        public PasswordValidatorFactory_UnitTests()
        {
            _validatorFactory = new PasswordValidatorFactory();
        }

        [TestCase("simple")]
        [TestCase("Simple")]
        public void GetPasswordValidator_SimpleValidator_ShouldReturnSimpleValidator(string validatorType)
        {
            var validator = _validatorFactory.GetPasswordValidator(validatorType);
            Assert.IsInstanceOf<SimpleValidator>(validator);
        }

        [TestCase("advanced")]
        [TestCase("Advanced")]
        public void GetPasswordValidator_AdvancedValidator_ShouldReturnAdvancedValidator(string validatorType)
        {
            var validator = _validatorFactory.GetPasswordValidator(validatorType);
            Assert.IsInstanceOf<AdvancedValidator>(validator);
        }

        [TestCase("unknown")]
        [TestCase("Advance")]
        [TestCase("simpleton")]
        [TestCase("")]
        [TestCase("fjeiji3")]
        public void GetPasswordValidator_UnknownValidatorType_ShouldReturnArgumentException(string validatorType)
        {
            Assert.Throws<System.ArgumentException>(() => _validatorFactory.GetPasswordValidator(validatorType));
        }
    }
}
