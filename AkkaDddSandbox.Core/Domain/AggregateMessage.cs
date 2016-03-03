using Akka.Actor;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Domain
{
    public class AggregateMessage
    {
        public AggregateMessage(AggregateId id, object message, IActorRef sender)
        {
            Id = id;
            Message = message;
            Sender = sender;
        }

        public AggregateId Id { get; }
        public object Message { get; }
        public IActorRef Sender { get; }
    }
}