using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateName : IDomainCommand<Respondent>
    {
        public UpdateName(RespondentId id, string firstName, string lastName)
        {
            AggregateId = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public AggregateId AggregateId { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}