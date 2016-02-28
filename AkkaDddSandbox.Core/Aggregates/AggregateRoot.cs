using System;
using Akka.Persistence;
using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Aggregates
{
    public abstract class AggregateRoot<TState> : ReceivePersistentActor
    {
        const int SnapshotAfter = 3;
        protected TState State { get; set; }

        protected bool Initialized => State != null;

        private int _eventCount = 0;

        protected AggregateRoot(string id)
        {
            PersistenceId = id;

            Recover<SnapshotOffer>(offer =>
            {
                if (offer.Snapshot is TState)
                    State = (TState)offer.Snapshot;
            });
            Recover((Action<IDomainEvent>) UpdateState);
        }

        public sealed override string PersistenceId { get; }

        public abstract void UpdateState(IDomainEvent domainEvent);

        protected void Emit<TEvent>(TEvent domainEvent, Action<TEvent> handler = null) where TEvent : IDomainEvent
        {
            Persist(domainEvent, e =>
            {
                UpdateState(e);
                SaveSnapshotIfNecessary();
                handler?.Invoke(e);
            });
        }

        private void SaveSnapshotIfNecessary()
        {
            _eventCount = (_eventCount + 1) % SnapshotAfter;
            if (_eventCount == 0 && State != null)
            {
                SaveSnapshot(State);
            }
        }
    }
}
