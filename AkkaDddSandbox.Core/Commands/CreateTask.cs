using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class CreateTask : IDomainCommand<Task>
    {
        public CreateTask(TaskId aggregateId)
        {
            AggregateId = aggregateId;
        }

        public AggregateId AggregateId { get; }
    }
}