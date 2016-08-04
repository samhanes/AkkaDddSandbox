using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Respondent : AggregateRoot<RespondentModel>, ICommandHandler<RespondentCommand>
    {
        private readonly RespondentId _id;

        public Respondent(RespondentId id) : base(id)
        {
            _id = id;
            State = null;
            
            Command<CreateRespondent>(cmd =>
            {
                // todo: validate commands
                Emit(new RespondentCreated(_id, cmd.FirstName, cmd.LastName, cmd.TimeZone));
                Become(Initialized);
            });
        }

        protected override void Initialized()
        {
            Command<UpdateName>(cmd => Emit(new RespondentNameUpdated(_id, cmd.FirstName, cmd.LastName)));
            Command<UpdateTimeZone>(cmd => Emit(new RespondentTimeZoneUpdated(_id, cmd.TimeZone)));
        }

        protected override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<RespondentCreated>(ev => State = new RespondentModel(ev.FirstName, ev.LastName, ev.TimeZone, "Start"))
                .With<RespondentNameUpdated>(ev => State = State.With(firstName: ev.UpdatedFirst, lastName: ev.UpdatedLast))
                .With<RespondentTimeZoneUpdated>(ev => State = State.With(timeZone: ev.UpdatedTimeZone));
        }
    }
}