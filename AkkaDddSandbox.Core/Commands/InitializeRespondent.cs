using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class InitializeRespondent : IDomainCommand<Respondent>
    {
        public InitializeRespondent(RespondentId id, string firstName, string lastName, string timeZone)
        {
            AggregateId = id;
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
        }

        public AggregateId AggregateId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
    }
}