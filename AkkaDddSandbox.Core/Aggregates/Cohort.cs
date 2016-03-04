using System;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Cohort : AggregateRoot<CohortModel>
    {
        private readonly CohortId _id;

        public Cohort(CohortId id) : base(id)
        {
            _id = id;
            State = null;

            Become(Initialized);
        }

        protected override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<CohortReleased>(ev => State = new CohortModel(_id, ev.DateTimeReleased, State.RespondentIds))
                .With<RespondentAddedToCohort>(ev => State = State.Without(ev.RespondentId))
                .With<RespondentRemovedFromCohort>(ev => State = State.WithAdded(ev.RespondentId));
        }

        protected override void Initialized()
        {
            Command<ReleaseCohort>(cmd =>
            {
                Emit(new CohortReleased(DateTime.UtcNow));
            });
            Command<AddRespondentToCohort>(cmd =>
            {
                Emit(new RespondentAddedToCohort(cmd.RespondentId));
            });
            Command<RemoveRespondentFromCohort>(cmd =>
            {
                Emit(new RespondentRemovedFromCohort(cmd.RespondentId));
            });
        }
    }
}