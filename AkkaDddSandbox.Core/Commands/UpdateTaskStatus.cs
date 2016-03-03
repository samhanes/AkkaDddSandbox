using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTaskStatus : IDomainCommand<Task>
    {
        public UpdateTaskStatus(TaskId id, string newStatus)
        {
            AggregateId = id;
            NewStatus = newStatus;
        }

        public AggregateId AggregateId { get; }
        public string NewStatus { get; }
    }
}