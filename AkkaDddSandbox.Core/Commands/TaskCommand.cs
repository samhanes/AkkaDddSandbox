using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public abstract class TaskCommand : IDomainCommand
    {
        protected TaskCommand(TaskId id)
        {
            Id = id;
        }

        public TaskId Id { get; }
        public AggregateId AggregateId => Id;
    }
}