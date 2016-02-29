using System.Collections.Generic;
using System.Collections.ObjectModel;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Respondent : AggregateRoot<RespondentModel>
    {
        public Respondent(RespondentId id) : base(id)
        {
            Id = id;
            State = null;
            
            Command<InitializeRespondent>(cmd =>
            {
                Emit(new RespondentInitialized(Id, cmd.FirstName, cmd.LastName, cmd.TimeZone));
                Become(Initialized);
            });
        }

        public RespondentId Id { get; }

        private void Initialized()
        {
            Command<UpdateName>(cmd =>
            {
                Emit(new RespondentNameUpdated(Id, cmd.FirstName, cmd.LastName));
            });

            Command<UpdateTimeZone>(cmd =>
            {
                Emit(new RespondentTimeZoneUpdated(Id, cmd.TimeZone));
            });
        }

        public override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<RespondentInitialized>(
                    ev => State =
                            new RespondentModel(ev.FirstName, ev.LastName, ev.TimeZone, "Start",
                                new ReadOnlyDictionary<TaskId, TaskModel>(new Dictionary<TaskId, TaskModel>()),
                                new ReadOnlyDictionary<ProtocolEventId, ProtocolEventModel>(
                                new Dictionary<ProtocolEventId, ProtocolEventModel>())))
                .With<RespondentNameUpdated>(ev => State = State.With(firstName: ev.UpdatedFirst, lastName: ev.UpdatedLast))
                .With<RespondentTimeZoneUpdated>(ev => State =State.With(timeZone: ev.UpdatedTimeZone));
        }
    }
}