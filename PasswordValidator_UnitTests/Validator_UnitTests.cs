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
    }
}