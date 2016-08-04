using System;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Task : AggregateRoot<TaskModel>, ICommandHandler<TaskCommand>
    {
        private readonly TaskId _id;

        public Task(TaskId id) : base(id)
        {
            _id = id;
            State = null;

            Command<CreateTask>(cmd =>
            {
                Emit(new TaskCreated(_id, DateTime.UtcNow));
                Become(Initialized);
            });
        }

        protected override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<TaskCreated>(ev => State = new TaskModel("Authorized", ev.DateTimeCreated))
                .With<TaskStatusUpdated>(ev => State = State.With(status: ev.NewStatus, dateTimeStatusSet: ev.DateTimeUpdated));
        }

        protected override void Initialized()
        {
            Command<UpdateTaskStatus>(cmd =>
            {
                Emit(new TaskStatusUpdated(_id, cmd.NewStatus, DateTime.UtcNow));
            });
        }
    }
}