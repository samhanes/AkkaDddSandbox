using Akka.Actor;
using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Domain
{
    public class CommandDispatcher : ReceiveActor
    {
        private readonly IAggregateTypeProvider _aggregateTypeProvider;

        public CommandDispatcher(IAggregateTypeProvider aggregateTypeProvider)
        {
            _aggregateTypeProvider = aggregateTypeProvider;
            Receive<IDomainCommand>(cmd => DispatchCommand(cmd));
        }

        private void DispatchCommand(IDomainCommand cmd)
        {
            var aggregateType = _aggregateTypeProvider.GetAggregateType(cmd.GetType());

            var actorName = aggregateType.FullName;
            var aggregateDispatcher = Context.Child(actorName);
            if (aggregateDispatcher.IsNobody())
            {
                var dispatcherType = typeof(AggregateDispatcher<>).MakeGenericType(aggregateType);
                aggregateDispatcher = Context.ActorOf(Props.Create(dispatcherType), actorName);
            }

            aggregateDispatcher.Tell(cmd);
        }
    }
}