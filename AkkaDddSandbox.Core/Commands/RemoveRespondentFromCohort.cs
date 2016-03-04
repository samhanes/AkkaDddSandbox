using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class RemoveRespondentFromCohort : IDomainCommand<Cohort>
    {
        public RemoveRespondentFromCohort(CohortId aggregateId, RespondentId respondentId)
        {
            AggregateId = aggregateId;
            RespondentId = respondentId;
        }

        public AggregateId AggregateId { get; }
        public RespondentId RespondentId { get; }
    }
}