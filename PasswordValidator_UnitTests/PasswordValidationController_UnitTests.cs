using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PasswordValidator;
using PasswordValidator.Controllers;
using NUnit.Framework;
using System;

namespace PasswordValidator_UnitTests
{
    public class PasswordValidationController_UnitTests
    {
        IValidatorFactory _validatorFactory = Substitute.For<IValidatorFactory>();
        IPasswordValidator _validator = Substitute.For<IPasswordValidator>();

        [Test]
        public void ValidatePassword_ShouldReturnOkObjectResult()
        {
            string password = string.Empty;
            _validatorFactory.GetPasswordValidator("Simple").Returns(_validator);
            _validator.Validate(password).Returns(true);
            PasswordValidationController controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidatePassword(password);

            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        public void ValidatePassword_ShouldReturnBadRequest()
        {
            string password = string.Empty;
            _validatorFactory.GetPasswordValidator("Simple").Returns(_validator);
            _validator.Validate(password).Returns(false);
            PasswordValidationController controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidatePassword(password);

            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult);
        }

        [Test]
        public void ValidateAdvancedPassword_ShouldReturnOkObjectResult()
        {
            string password = string.Empty;
            _validatorFactory.GetPasswordValidator("Advanced").Returns(_validator);
            _validator.Validate(password).Returns(true);
            PasswordValidationController controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidateAdvancedPassword(password);

            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        public void ValidateAdvancedPassword_ShouldReturnBadRequest()
        {
            string password = string.Empty;
            _validatorFactory.GetPasswordValidator("Advanced").Returns(_validator);
            _validator.Validate(password).Returns(false);
            PasswordValidationController controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidateAdvancedPassword(password);

            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult);
        }
    }
}
