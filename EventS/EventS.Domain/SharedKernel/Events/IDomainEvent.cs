using System;

namespace EventS.Domain.SharedKernel.Events
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurred { get; }

        Guid Id { get; }

        void Process();
    }

    
}