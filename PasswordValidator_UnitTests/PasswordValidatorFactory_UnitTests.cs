using PasswordValidator.Factories;
using PasswordValidator.Validators;
using NUnit.Framework;
using PasswordValidator.Enums;

namespace PasswordValidator_UnitTests
{
    internal class PasswordValidatorFactory_UnitTests
    {
        private readonly IValidatorFactory _validatorFactory;

        public PasswordValidatorFactory_UnitTests()
        {
            _validatorFactory = new PasswordValidatorFactory();
        }

        [Test]
        public void GetPasswordValidator_SimpleValidator_ShouldReturnSimpleValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator(ValidatorType.simple);
            Assert.IsInstanceOf<SimpleValidator>(validator);
        }

        [Test]
        public void GetPasswordValidator_AdvancedValidator_ShouldReturnAdvancedValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator(ValidatorType.advanced);
            Assert.IsInstanceOf<AdvancedValidator>(validator);
        }
    }
}
