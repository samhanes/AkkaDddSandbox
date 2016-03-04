using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class AddRespondentToCohort : IDomainCommand<Cohort>
    {
        public AddRespondentToCohort(CohortId aggregateId, RespondentId respondentId)
        {
            AggregateId = aggregateId;
            RespondentId = respondentId;
        }

        public AggregateId AggregateId { get; }
        public RespondentId RespondentId { get; }
    }
}