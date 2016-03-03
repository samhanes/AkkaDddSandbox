using Akka.Actor;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Domain
{
    public class AggregateRef : ICanTell
    {
        private readonly AggregateId _id;
        private readonly IActorRef _dispatcher;

        public AggregateRef(AggregateId id, IActorRef dispatcher)
        {
            _id = id;
            _dispatcher = dispatcher;
        }

        public void Tell(object message, IActorRef sender)
        {
            _dispatcher.Tell(new AggregateMessage(_id, message, sender));
        }
    }
}