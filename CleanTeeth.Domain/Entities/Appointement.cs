using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObject;

namespace CleanTeeth.Domain.Entities
{
    public class Appointement
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointementStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointement(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
        {

            Id = Guid.NewGuid();
            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            Status = AppointementStatus.Scheduled;
            TimeInterval = timeInterval;

        }

        public void Cancel()
        {
            if (Status != AppointementStatus.Scheduled)
            {
                throw new BusinessRuleException("The appointement is not scheduled.");
            }

            if (Status == AppointementStatus.Canceled)
            {
                throw new BusinessRuleException("The appointement is already canceled.");
            }

            Status = AppointementStatus.Canceled;
        }

        public void Complete()
        {
            if (Status != AppointementStatus.Scheduled)
            {
                throw new BusinessRuleException("The appointement is not scheduled.");
            }

            Status = AppointementStatus.Completed;
        }
    }
}
