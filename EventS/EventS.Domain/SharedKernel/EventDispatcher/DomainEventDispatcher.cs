using System;
using System.Collections.Generic;
using System.Linq;
using EventS.Domain.SharedKernel.Events;
using Microsoft.Extensions.DependencyInjection;

namespace EventS.Domain.SharedKernel.EventDispatcher
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            IEnumerable<object> handlers = serviceProvider.GetServices(handlerType);

            IEnumerable<DomainEventHandler> wrappedHandlers = handlers
                .Select(handler => (DomainEventHandler) Activator.CreateInstance(wrapperType, handler));

            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                handler.Handle(domainEvent);
            }
        }

        private abstract class DomainEventHandler
        {
            public abstract void Handle(IDomainEvent domainEvent);
        }

        private class DomainEventHandler<T> : DomainEventHandler
            where T : IDomainEvent
        {
            private readonly IDomainEventHandler<T> handler;

            public DomainEventHandler(IDomainEventHandler<T> handler)
            {
                this.handler = handler;
            }

            public override void Handle(IDomainEvent domainEvent)
            {
                handler.Handle((T) domainEvent);
            }
        }
    }
}