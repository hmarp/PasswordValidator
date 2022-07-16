using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            SimpleValidator simpleValidator = new SimpleValidator();
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
            AdvancedValidator advancedValidator = new AdvancedValidator();
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
