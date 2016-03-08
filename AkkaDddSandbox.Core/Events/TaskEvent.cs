using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public abstract class TaskEvent : IDomainEvent
    {
        protected TaskEvent(TaskId id)
        {
            Id = id;
        }

        public TaskId Id { get; }
    }
}