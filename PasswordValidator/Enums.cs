namespace PasswordValidator.Enums
{
    public enum ValidatorType
    {
        Base,
        Simple,
        Advanced
    }

    public enum RuleType
    {
        SimpleLength,
        AdvancedLength,
        SimpleNumber,
        AdvancedNumber,
        ContainsSpecialCharacter
    }
}
