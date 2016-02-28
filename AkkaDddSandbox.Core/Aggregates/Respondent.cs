using System;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Respondent : AggregateRoot<RespondentModel>
    {
        public Respondent(string id) : base(id)
        {
            State = null;
            
            Command<InitializeRespondent>(cmd =>
            {
                if (Initialized)
                    throw new Exception($"Respondent with id: {id} is already initialized!");
                Emit(new RespondentInitialized(cmd.FirstName, cmd.LastName, cmd.TimeZone));
            });

            Command<AskState>(msg =>
            {
                Sender.Tell(State, Self);
            });

            Command<UpdateName>(_ => Initialized,
                cmd =>
                {
                    Emit(new NameUpdated(cmd.FirstName, cmd.LastName));
                });

            Command<UpdateTimeZone>(_ => Initialized,
                cmd =>
                {
                    Emit(new TimeZoneUpdated(cmd.TimeZone));
                });
        }

        public override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<RespondentInitialized>(
                    ev => State = new RespondentModel(ev.FirstName, ev.LastName, ev.TimeZone, "Start"))
                .With<NameUpdated>(
                    ev =>
                        State =
                            new RespondentModel(ev.UpdatedFirst, ev.UpdatedLast, State.TimeZone, State.TaskRulesState))
                .With<TimeZoneUpdated>(
                    ev =>
                        State =
                            new RespondentModel(State.FirstName, State.LastName, ev.UpdatedTimeZone,
                                State.TaskRulesState));
        }
    }
}