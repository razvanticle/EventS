using System;
using System.Collections.Generic;
using System.Linq;
using EventS.Domain.SharedKernel;
using EventS.Domain.SharedKernel.Events;

namespace EventS.Domain.Orders.Model
{
    public class Order : AggregateRoot<Guid>
    {
        private readonly IList<OrderItem> orderItems;

        public Order(Invoice invoice, IEnumerable<OrderItem> orderItems,
            PaymentMethod paymentMethod) : base(Guid.NewGuid())
        {
            Invoice = invoice;
            this.orderItems = orderItems.ToList();
            PaymentMethod = paymentMethod;

            Handle<NewOrderItemEvent>(HandlerAddOrderItem);
        }

        public Invoice Invoice { get; }

        public IEnumerable<OrderItem> OrderItems => orderItems;

        public PaymentMethod PaymentMethod { get; }

        public void HandlerAddOrderItem(NewOrderItemEvent newOrderItemEvent)
        {
            orderItems.Add(newOrderItemEvent.OrderItem);
        }
    }

    public class NewOrderItemEvent : DomainEvent
    {
        public NewOrderItemEvent(OrderItem orderItem, Order order)
        {
            OrderItem = orderItem;
            Order = order;
        }

        public Order Order { get; }

        public OrderItem OrderItem { get; }

        public override void Process()
        {
            Order.Process(this);
        }
    }

    public class AddOrderEvent:DomainEvent
    {
        public Store Store { get; set; }

        public Order Order { get; set; }

        public override void Process()
        {
            Store.Process(this);
        }
    }

    public class EventProcessor
    {
        private readonly IList<IDomainEvent> log = new List<IDomainEvent>();

        public void Process(IDomainEvent domainEvent)
        {
            domainEvent.Process();
            log.Add(domainEvent);
        }
    }

    public class Store:AggregateRoot<int>
    {
        public Store(int id) : base(id)
        {
            Orders = new List<Order>();
        }

        public IList<Order> Orders { get; }

        public void HandleAddOrder(Order order)
        {
            Orders.Add(order);
        } 
    }

}