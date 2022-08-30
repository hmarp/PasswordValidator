using PasswordValidator.Enums;

namespace PasswordValidator.Rules
{
    public interface IRule
    {
        public RuleType ruleType { get; set; }
        public bool Satisfied(string password);
    }
}
