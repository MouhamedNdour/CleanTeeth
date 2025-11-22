using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }  = null!;
        public string Email { get; private set; } = null!;

        public Patient(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"The {nameof(email)} cannot be null or empty.");
            }

            if (!email.Contains('@'))
            {
                throw new BusinessRuleException($"The {nameof(email)} must be a valid email address.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
