using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class ReleaseCohort : IDomainCommand<Cohort>
    {
        public ReleaseCohort(CohortId aggregateId)
        {
            AggregateId = aggregateId;
        }

        public AggregateId AggregateId { get; }
    }
}