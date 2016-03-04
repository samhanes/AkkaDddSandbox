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
        private readonly RespondentId _id;

        public Respondent(RespondentId id) : base(id)
        {
            _id = id;
            State = null;
            
            Command<InitializeRespondent>(cmd =>
            {
                // todo: validate commands
                Emit(new RespondentInitialized(cmd.FirstName, cmd.LastName, cmd.TimeZone));
                Become(Initialized);
            });
        }

        protected override void Initialized()
        {
            Command<UpdateName>(cmd =>
            {
                Emit(new RespondentNameUpdated(_id, cmd.FirstName, cmd.LastName));
            });

            Command<UpdateTimeZone>(cmd =>
            {
                Emit(new RespondentTimeZoneUpdated(_id, cmd.TimeZone));
            });
        }

        protected override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<RespondentInitialized>(
                    ev =>
                    {
                        State =
                            new RespondentModel(ev.FirstName, ev.LastName, ev.TimeZone, "Start",
                                new ReadOnlyDictionary<TaskId, TaskModel>(new Dictionary<TaskId, TaskModel>()),
                                new ReadOnlyDictionary<ProtocolEventId, ProtocolEventModel>(
                                    new Dictionary<ProtocolEventId, ProtocolEventModel>()));
                    })
                .With<RespondentNameUpdated>(
                    ev => State = State.With(firstName: ev.UpdatedFirst, lastName: ev.UpdatedLast))
                .With<RespondentTimeZoneUpdated>(ev => State = State.With(timeZone: ev.UpdatedTimeZone));
        }
    }
}