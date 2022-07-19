using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        readonly ValidatorFactory _validatorFactory = new ValidatorFactory();

        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            IPasswordValidator simpleValidator = _validatorFactory.GetValidator("Simple");
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
            IPasswordValidator advancedValidator = _validatorFactory.GetValidator("Advanced");
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
