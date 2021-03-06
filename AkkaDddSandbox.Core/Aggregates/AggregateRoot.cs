using System;
using System.Collections.Generic;
using Akka.Persistence;
using AkkaDddSandbox.Core.Exceptions;
using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Aggregates
{
    public abstract class AggregateRoot : ReceivePersistentActor {}

    public abstract class AggregateRoot<TState> : AggregateRoot
    {
        const int SnapshotAfter = 10;
        
        private long _eventCount = 0;
        private TState _state;

        protected AggregateRoot(AggregateId id)
        {
            PersistenceId = $"{GetType().FullName}:{id}";

            Recover<SnapshotOffer>(offer =>
            {
                if (offer.Snapshot is TState)
                    State = (TState)offer.Snapshot;
            });
            Recover((Action<IDomainEvent>) UpdateState);
        }
        
        public override string PersistenceId { get; }

        protected override void OnReplaySuccess()
        {
            base.OnReplaySuccess();
            _eventCount = LastSequenceNr % SnapshotAfter;
            if (_state != null)
                Become(Initialized);
        }

        protected TState State
        {
            get
            {
                if (_state == null) throw new AggregateRootNotInitializedException();
                return _state;
            }
            set { _state = value; }
        }

        protected abstract void UpdateState(IDomainEvent domainEvent);
        protected abstract void Initialized();

        protected void Emit<TEvent>(TEvent domainEvent, Action<TEvent> handler = null) where TEvent : IDomainEvent
        {
            Persist(domainEvent, e => OnEventPersisted(e, handler));
        }

        protected void Emit<TEvent>(IEnumerable<TEvent> domainEvents, Action<TEvent> handler = null) where TEvent : IDomainEvent
        {
            Persist(domainEvents, e => OnEventPersisted(e, handler));
        }

        private void OnEventPersisted<TEvent>(TEvent @event, Action<TEvent> handler) where TEvent : IDomainEvent
        {
            UpdateState(@event);
            SaveSnapshotIfNecessary();

            handler?.Invoke(@event);
            Context.System.EventStream.Publish(@event);
        }

        private void SaveSnapshotIfNecessary()
        {
            _eventCount = (_eventCount + 1) % SnapshotAfter;
            if (_eventCount == 0)
                SaveSnapshot(State);
        }
    }
}