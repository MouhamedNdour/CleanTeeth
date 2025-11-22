using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObject
{
    public record Email
    {
        public string Value { get; } = string.Empty;
        public Email(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"The {nameof(email)} cannot be null or empty.");
            }

            if (!email.Contains('@'))
            {
                throw new BusinessRuleException($"The {nameof(email)} must be a valid email address.");
            }

            Value = email;
        }
    }
}
