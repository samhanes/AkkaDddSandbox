using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentInitialized : IDomainEvent
    {
        public RespondentInitialized(string firstName, string lastName, string timeZone) 
        {
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
    }
}