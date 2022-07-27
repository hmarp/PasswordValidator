using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        readonly IValidatorFactory _validatorFactory;

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
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            if (isValid)
            {
                return Ok("Valid Password");
            }
            else
            {
                return BadRequest("Invalid Password");
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
            }
            catch
            {
                return StatusCode(500);
            }

            if (isValid)
            {
                return Ok("Valid Advanced Password");
            }
            else
            {
                return BadRequest("Invalid Advanced Password");
            }
        }
    }
}
