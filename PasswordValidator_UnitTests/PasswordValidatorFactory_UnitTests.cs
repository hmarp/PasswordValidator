using PasswordValidator.Factories;
using PasswordValidator.Validators;
using NUnit.Framework;
using PasswordValidator.Enums;
using System.Collections.Generic;
using PasswordValidator.Rules;

namespace PasswordValidator_UnitTests
{
    internal class PasswordValidatorFactory_UnitTests
    {
        private readonly IValidatorFactory _validatorFactory;

        public PasswordValidatorFactory_UnitTests()
        {
            var rules = new List<IRule>
            {
                new AdvancedLengthRule(),
                new AdvancedNumberRule(),
                new SimpleLengthRule(),
                new SimpleNumberRule(),
                new ContainsSpecialCharacterRule()
            };

            IPasswordValidator[] validators = new IPasswordValidator[] { new SimpleValidator(rules), new AdvancedValidator(rules) };
            _validatorFactory = new PasswordValidatorFactory(validators);
        }

        [Test]
        public void GetPasswordValidator_SimpleValidator_ShouldReturnSimpleValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator(ValidatorType.Simple);
            Assert.IsInstanceOf<SimpleValidator>(validator);
        }

        [Test]
        public void GetPasswordValidator_AdvancedValidator_ShouldReturnAdvancedValidator()
        {
            var validator = _validatorFactory.GetPasswordValidator(ValidatorType.Advanced);
            Assert.IsInstanceOf<AdvancedValidator>(validator);
        }
    }
}
