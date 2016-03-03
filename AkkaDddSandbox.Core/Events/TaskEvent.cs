using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class TaskEvent : IDomainEvent
    {
        public TaskEvent(TaskId id)
        {
            Id = id;
        }

        public TaskId Id { get; }
    }
}