using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        readonly SimpleValidatorFactory _SimpleValidatorFactory = new SimpleValidatorFactory();
        readonly AdvancedValidatorFactory _AdvancedValidatorFactory = new AdvancedValidatorFactory();

        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            IPasswordValidator simpleValidator = _SimpleValidatorFactory.CreateValidator();
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
            IPasswordValidator advancedValidator = _AdvancedValidatorFactory.CreateValidator();
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
