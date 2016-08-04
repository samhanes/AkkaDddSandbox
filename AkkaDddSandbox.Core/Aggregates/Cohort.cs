using System;
using System.Collections.Generic;
using Akka;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public class Cohort : AggregateRoot<CohortModel>, ICommandHandler<CohortCommand>
    {
        private readonly CohortId _id;

        public Cohort(CohortId id) : base(id)
        {
            _id = id;
            State = null;

            Command<CreateRespondent>(cmd =>
            {
                Emit(new CohortCreated(_id));
                Become(Initialized);
            });
        }

        protected override void UpdateState(IDomainEvent domainEvent)
        {
            domainEvent.Match()
                .With<CohortCreated>(ev => State = new CohortModel(_id, null, new List<RespondentId>()))
                .With<CohortReleased>(ev => State = new CohortModel(_id, ev.DateTimeReleased, State.RespondentIds))
                .With<RespondentAddedToCohort>(ev => State = State.Without(ev.RespondentId))
                .With<RespondentRemovedFromCohort>(ev => State = State.WithAdded(ev.RespondentId));
        }

        protected override void Initialized()
        {
            Command<ReleaseCohort>(cmd =>
            {
                Emit(new CohortReleased(DateTime.UtcNow, State.RespondentIds));
            });
            Command<AddRespondentToCohort>(cmd =>
            {
                Emit(new RespondentAddedToCohort(cmd.RespondentId, State.IsReleased));
            });
            Command<RemoveRespondentFromCohort>(cmd =>
            {
                Emit(new RespondentRemovedFromCohort(cmd.RespondentId));
            });
        }
    }
}