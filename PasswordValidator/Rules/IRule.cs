using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public interface IRule
    {
        public RuleType Type { get; }
        public bool Satisfied(string password);
    }
}
