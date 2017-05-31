using System;
using System.Collections.Generic;
using EventS.Domain.SharedKernel.Events;

namespace EventS.Domain.SharedKernel
{
    public class AggregateRoot<TId> : Entity<TId>
    {
        private readonly IList<IDomainEvent> domainEvents;

        private readonly IDictionary<Type, Delegate> handlers = new Dictionary<Type, Delegate>();

        public AggregateRoot(TId id) : base(id)
        {
            domainEvents = new List<IDomainEvent>();
        }

        public IEnumerable<IDomainEvent> DomainEvents => domainEvents;

        public void AddEvent(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void ClearEvents()
        {
            domainEvents.Clear();
        }

        public void Handle<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
        {
            handlers.Add(typeof(TEvent), handler);
        }

        public void Process(IDomainEvent domainEvent)
        {
            Type eventType = domainEvent.GetType();
            Delegate handler;
            if (handlers.TryGetValue(eventType, out handler))
            {
                handler.DynamicInvoke(domainEvent);
            }
            
        }
    }
}