﻿using PasswordValidator.Enums;

namespace PasswordValidator.Validators
{
    public class SimpleValidator : IPasswordValidator
    {
        public ValidatorType ValidatorType => ValidatorType.Simple;

        public bool Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"{nameof(password)} cannot be null or whitespace");
            }

            bool isValidLength = (password.Length >= 6) && (password.Length <= 12);
            bool containsNumber = password.Any(char.IsDigit);
            bool containsSpecialCharacter = password.Any(character => !char.IsLetterOrDigit(character));

            return isValidLength && containsNumber && containsSpecialCharacter;
        }
    }
}
