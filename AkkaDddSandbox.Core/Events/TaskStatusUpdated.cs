using System;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class TaskStatusUpdated : TaskEvent
    {
        public TaskStatusUpdated(TaskId id, string newStatus, DateTime dateTimeUpdated) : base(id)
        {
            NewStatus = newStatus;
            DateTimeUpdated = dateTimeUpdated;
        }

        public string NewStatus { get; }
        public DateTime DateTimeUpdated { get; }
    }
}