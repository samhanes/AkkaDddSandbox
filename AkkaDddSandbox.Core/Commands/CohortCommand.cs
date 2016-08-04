using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public abstract class CohortCommand : IDomainCommand
    {
        protected CohortCommand(CohortId id)
        {
            Id = id;
        }

        public CohortId Id { get; }
        public AggregateId AggregateId => Id;
    }
}