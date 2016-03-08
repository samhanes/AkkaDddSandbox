using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentCreated : RespondentEvent
    {
        public RespondentCreated(RespondentId id, string firstName, string lastName, string timeZone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
    }

    public abstract class RespondentEvent : IDomainEvent
    {
        protected RespondentEvent(RespondentId id)
        {
            Id = id;
        }

        public RespondentId Id { get; }
    }
}