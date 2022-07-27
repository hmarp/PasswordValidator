using PasswordValidator;
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

        [Test]
        public void GetPasswordValidator_SimpleValidator_ShouldReturnSimpleValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator("Simple");
            Assert.IsInstanceOf<SimpleValidator>(validator);
        }

        [Test]
        public void GetPasswordValidator_AdvancedValidator_ShouldReturnAdvancedValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator("Advanced");
            Assert.IsInstanceOf<AdvancedValidator>(validator);
        }
    }
}
