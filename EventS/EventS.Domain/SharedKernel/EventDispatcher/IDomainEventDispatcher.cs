using EventS.Domain.SharedKernel.Events;

namespace EventS.Domain.SharedKernel.EventDispatcher
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}