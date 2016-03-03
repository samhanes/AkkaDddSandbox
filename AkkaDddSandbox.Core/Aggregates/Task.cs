using System;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Task : AggregateRoot<TaskModel>
    {
        public Task(TaskId id) : base(id)
        {
            Id = id;
            State = new TaskModel("Authorized", DateTime.UtcNow);

            Command<UpdateTaskStatus>(cmd =>
            {
                Emit(new TaskStatusUpdated(Id, cmd.NewStatus, DateTime.UtcNow));
            });
        }

        public TaskId Id { get; }

        public override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<TaskStatusUpdated>(ev => State = State.With(status: ev.NewStatus, dateTimeStatusSet: ev.DateTimeUpdated));
        }
    }
}