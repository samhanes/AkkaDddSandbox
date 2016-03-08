using System;
using System.Collections.Generic;
using Akka.Actor;
using Akka.Configuration;
using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Domain
{
    public interface IDomainModel : IDisposable
    {
        void Dispatch<T>(IDomainCommand<T> command) where T : AggregateRoot;
    }

    public class DomainModel : IDomainModel
    {
        private readonly IDictionary<Type, IActorRef> _aggregateDispatcherRegistry = new Dictionary<Type, IActorRef>();
        private readonly ActorSystem _system;

        public DomainModel(string name)
        {
            _system = ActorSystem.Create(name);
        }

        public DomainModel(string name, Config config)
        {
            _system = ActorSystem.Create(name, config);
        }
        
        public void Dispatch<T>(IDomainCommand<T> command) where T : AggregateRoot
        {
            var aggregate = AggregateOf<T>(command.AggregateId);
            aggregate.Tell(command, null);
        }

        public void RegisterHandler<T>() where T : ActorBase, new()
        {
            _system.ActorOf<T>();
        }

        private AggregateRef AggregateOf<T>(AggregateId id) where T : AggregateRoot
        {
            if (!_aggregateDispatcherRegistry.ContainsKey(typeof(T)))
                _aggregateDispatcherRegistry[typeof(T)] = _system.ActorOf(Props.Create<AggregateDispatcher<T>>(), typeof(T).FullName);

            var cache = _aggregateDispatcherRegistry[typeof(T)];
            return new AggregateRef(id, cache);
        }

        public void Dispose()
        {
            _system.Terminate();
        }
    }
}