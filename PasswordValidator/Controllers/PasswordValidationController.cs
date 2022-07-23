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
            IPasswordValidator simpleValidator = _validatorFactory.GetPasswordValidator("Simple");
            bool isValid = simpleValidator.Validate(password);

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
            IPasswordValidator advancedValidator = _validatorFactory.GetPasswordValidator("Advanced");
            bool isValid = advancedValidator.Validate(password);

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
