using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            bool isValid = Validator.IsValidPassword(password);

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
            bool isValid = Validator.isValidAdvancedPassword(password);

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
