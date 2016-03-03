using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTimeZone : IDomainCommand<Respondent>
    {
        public UpdateTimeZone(RespondentId id, string timeZone)
        {
            AggregateId = id;
            TimeZone = timeZone;
        }

        public AggregateId AggregateId { get; }
        public string TimeZone { get; }
    }
}