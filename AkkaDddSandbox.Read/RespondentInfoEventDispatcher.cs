using Akka.Actor;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Read
{
    public class RespondentInfoEventDispatcher : ReceiveActor
    {
        public RespondentInfoEventDispatcher()
        {
            //Context.System.EventStream.Subscribe(Self, typeof (RespondentCreated));
            Context.System.EventStream.Subscribe(Self, typeof (RespondentEvent));
            Context.System.EventStream.Subscribe(Self, typeof (TaskEvent));
            Context.System.EventStream.Subscribe(Self, typeof (CohortEvent));

            //Receive<RespondentCreated>(msg => ForwardToHandler(msg.Id, msg));
            Receive<RespondentEvent>(msg => ForwardToHandler(msg.Id, msg));
            Receive<TaskEvent>(msg => ForwardToHandler(new RespondentId(msg.Id.RespondentId), msg));
            Receive<RespondentAddedToCohort>(msg => ForwardToHandler(msg.RespondentId, msg));
            Receive<RespondentRemovedFromCohort>(msg => ForwardToHandler(msg.RespondentId, msg));
            Receive<CohortReleased>(msg =>
            {
                foreach (var respondentId in msg.RespondentIds)
                {
                    ForwardToHandler(respondentId, msg);
                }
            });
        }

        private void ForwardToHandler(RespondentId id, IDomainEvent msg)
        {
            var actorName = id.ToString();
            var handler = Context.Child(actorName);
            if (handler.IsNobody())
                handler = Context.ActorOf(Props.Create(typeof (RespondentInfoProjectionHandler), id), actorName);

            handler.Tell(msg, Self);
        }
    }
}