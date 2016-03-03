using Akka.Actor;
using AkkaDddSandbox.Core.Aggregates;

namespace AkkaDddSandbox.Core.Domain
{
    public class AggregateDispatcher<T> : ReceiveActor where T : AggregateRoot
    {
        public AggregateDispatcher()
        {
            Receive<AggregateMessage>(msg => DispatchMessage(msg));
        }

        public void DispatchMessage(AggregateMessage msg)
        {
            var actorName = msg.Id.ToString();
            var aggregate = Context.Child(actorName);
            if (aggregate.IsNobody())
                aggregate = Context.ActorOf(Props.Create(typeof(T), msg.Id), actorName);
            aggregate.Tell(msg.Message, msg.Sender);
        }
    }
}