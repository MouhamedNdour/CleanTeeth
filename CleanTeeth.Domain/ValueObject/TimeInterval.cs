using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObject
{
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("The start time must be before the end time.");
            }

            if (start < DateTime.Now)
            {
                throw new BusinessRuleException("The start time must be in the future.");
            }

            Start = start;
            End = end;
        }
    }
}
