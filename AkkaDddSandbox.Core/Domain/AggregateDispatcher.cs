using Akka.Actor;
using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Domain
{
    public class AggregateDispatcher<T> : ReceiveActor where T : AggregateRoot
    {
        public AggregateDispatcher()
        {
            Receive<IDomainCommand>(msg => DispatchMessage(msg));
        }

        public void DispatchMessage(IDomainCommand cmd)
        {
            var actorName = cmd.AggregateId.ToString();
            var aggregate = Context.Child(actorName);
            if (aggregate.IsNobody())
                aggregate = Context.ActorOf(Props.Create(typeof(T), cmd.AggregateId), actorName);

            aggregate.Tell(cmd);
        }
    }
}