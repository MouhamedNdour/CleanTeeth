using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObject;

namespace CleanTeeth.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }  = null!;
        public Email Email { get; private set; } = null!;

        public Patient(string name, Email email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} cannot be null or empty.");
            }

            if(email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} cannot be null.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
