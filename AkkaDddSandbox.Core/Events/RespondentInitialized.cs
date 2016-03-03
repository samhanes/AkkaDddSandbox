using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentInitialized : IDomainEvent
    {
        public RespondentInitialized(RespondentId id, string firstName, string lastName, string timeZone) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
        }

        public RespondentId Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
    }
}