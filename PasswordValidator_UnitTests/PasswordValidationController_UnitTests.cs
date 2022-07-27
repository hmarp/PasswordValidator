using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PasswordValidator;
using PasswordValidator.Controllers;
using NUnit.Framework;
using System;
using Microsoft.AspNetCore.Http;

namespace PasswordValidator_UnitTests
{
    public class PasswordValidationController_UnitTests
    {
        private readonly IValidatorFactory _validatorFactory = Substitute.For<IValidatorFactory>();
        private readonly IPasswordValidator _validator = Substitute.For<IPasswordValidator>();

        [Test]
        public void ValidatePassword_ShouldReturnOkObjectResult()
        {
            string password = string.Empty;

            _validatorFactory.GetPasswordValidator("Simple")
                .Returns(_validator);

            _validator.Validate(password)
                .Returns(true);

            var controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidatePassword(password) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, actionResult?.StatusCode);
        }

        [Test]
        public void ValidatePassword_ShouldReturnBadRequest()
        {
            string password = string.Empty;

            _validatorFactory.GetPasswordValidator("Simple")
                .Returns(_validator);

            _validator.Validate(password)
                .Returns(false);

            var controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidatePassword(password) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult?.StatusCode);
        }

        [Test]
        public void ValidateAdvancedPassword_ShouldReturnOkObjectResult()
        {
            string password = string.Empty;

            _validatorFactory.GetPasswordValidator("Advanced")
                .Returns(_validator);

            _validator.Validate(password)
                .Returns(true);

            var controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidateAdvancedPassword(password);

            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }

        [Test]
        public void ValidateAdvancedPassword_ShouldReturnBadRequest()
        {
            string password = string.Empty;

            _validatorFactory.GetPasswordValidator("Advanced")
                .Returns(_validator);

            _validator.Validate(password)
                .Returns(false);

            var controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidateAdvancedPassword(password);

            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult);
        }

        [Test]
        public void ValidatePassword_ValidateThrowsException_ShouldReturn500StatusCode()
        {
            string password = string.Empty;

            _validatorFactory.GetPasswordValidator("Simple")
                .Returns(_validator);

            _validator.Validate(password)
                .Returns(x => { throw new Exception(); });

            var controller = new PasswordValidationController(_validatorFactory);

            var actionResult = controller.ValidatePassword(password);

            Assert.AreEqual(StatusCodes.Status500InternalServerError, actionResult);
        }
    }
}
