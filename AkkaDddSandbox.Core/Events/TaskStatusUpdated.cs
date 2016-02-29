using System;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class TaskStatusUpdated : IDomainEvent
    {
        public TaskStatusUpdated(TaskId id, string newStatus, DateTime dateTimeUpdated)
        {
            Id = id;
            NewStatus = newStatus;
            DateTimeUpdated = dateTimeUpdated;
        }

        public TaskId Id { get; }
        public string NewStatus { get; }
        public DateTime DateTimeUpdated { get; }
    }
}