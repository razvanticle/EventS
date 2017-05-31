using System;

namespace EventS.Domain.SharedKernel.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
            DateTimeEventOccurred = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public DateTime DateTimeEventOccurred { get; }

        public Guid Id { get; }

        public abstract void Process();
    }
}