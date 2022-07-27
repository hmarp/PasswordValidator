﻿using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;

        public PasswordValidationController(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            bool isValid;

            try
            {
                var simpleValidator = _validatorFactory.GetPasswordValidator("Simple");
                isValid = simpleValidator.Validate(password);

                if (isValid)
                {
                    return Ok("Valid Password");
                }
                else
                {
                    return BadRequest("Invalid Password");
                }
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet]
        [Route("ValidateAdvancedPassword")]
        public ActionResult ValidateAdvancedPassword(string password)
        {
            bool isValid;

            try
            {
                var advancedValidator = _validatorFactory.GetPasswordValidator("Advanced");
                isValid = advancedValidator.Validate(password);

                if (isValid)
                {
                    return Ok("Valid Advanced Password");
                }
                else
                {
                    return BadRequest("Invalid Advanced Password");
                }
            }
            catch
            {
                return Problem();
            }            
        }
    }
}
