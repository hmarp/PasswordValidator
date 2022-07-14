using Microsoft.AspNetCore.Mvc;

namespace PasswordValidator.Controllers
{
    public class PasswordValidationController : Controller
    {
        [HttpGet]
        [Route("ValidatePassword")]
        public ActionResult ValidatePassword(string password)
        {
            bool isCorrectLength = (password.Length >= 6) && (password.Length <= 12);
            bool containsNumber = password.Any(char.IsDigit);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

            if (isCorrectLength && containsNumber && containsSpecialCharacter)
            {
                return Ok("Valid Password");
            }
            else
            {
                return BadRequest("Invalid Password");
            } 
        }
    }
}
