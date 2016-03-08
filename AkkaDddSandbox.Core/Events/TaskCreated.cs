using System;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class TaskCreated : TaskEvent
    {
        public TaskCreated(TaskId id, DateTime dateTimeCreated) : base(id)
        {
            DateTimeCreated = dateTimeCreated;
        }

        public DateTime DateTimeCreated { get; }
    }
}