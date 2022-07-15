using NUnit.Framework;
using PasswordValidator;

namespace PasswordValidator_UnitTests
{
    public class Validator_UnitTests
    {

        [TestCase("0erknn3#1")]
        [TestCase("@fjeiapfio3")]
        [TestCase("fdnke4442-2")]
        public void IsValidPassword_ValidPassword_ShouldReturnTrue(string password)
        {
            bool result = Validator.IsValidPassword(password);

            Assert.IsTrue(result);
        }

        [TestCase("fnekafjnkle3243-a{", Description="Too Long")]
        [TestCase("fa#3", Description="Too Short")]
        [TestCase("feafee@@ae", Description="Does Not Contain Number")]
        [TestCase("nfn2232ier", Description="Does Not Contain Special Character")]
        public void IsValidPassword_InvalidPassword_ShouldReturnFalse(string password)
        {
            bool result = Validator.IsValidPassword(password);

            Assert.IsFalse(result);
        }

        [TestCase("aieinr343_3@")]
        [TestCase("111dfjiea@e3")]
        [TestCase("fdaen@11111112")]
        [TestCase("3jda;af4fdaffede4")]
        public void IsValidAdvancedPassword_ValidPassword_ShouldReturnTrue(string advancedPassword)
        {
            bool result = Validator.isValidAdvancedPassword(advancedPassword);

            Assert.IsTrue(result);
        }

        [TestCase("eifn-fhje@ee33flren", Description="Too Long")]
        [TestCase("22@rekfev", Description="Too Short")]
        [TestCase("1jie@rneff", Description="Not Enough Numbers")]
        [TestCase("2300fmnenvieu", Description="No Special Character")]
        public void IsValidAdvancedPassword_InvalidPassword_ShouldReturnFalse(string advancedPassword)
        {
            bool result = Validator.isValidAdvancedPassword(advancedPassword);

            Assert.IsFalse(result);
        }
    }
}