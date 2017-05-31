using System;
using System.Linq;
using EventS.Domain.Orders.Model;
using EventS.Domain.SharedKernel.Model;

namespace EventS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EventProcessor eventProcessor = new EventProcessor();

            Store store = new Store(1);

            Order order = new Order(new Invoice(new Address("cluj", "22", "garibladi")), Enumerable.Empty<OrderItem>(),
                new PaymentMethod(PaymentMethodType.Cash));

            Order order2 = new Order(new Invoice(new Address("cluj", "22", "garibladi")), Enumerable.Empty<OrderItem>(),
                new PaymentMethod(PaymentMethodType.Cash));

            OrderItem orderItem1 = new OrderItem(new Service(), new Address("cluj", "22", "garibaldi"));
            OrderItem orderItem2 = new OrderItem(new Service(), new Address("cluj", "22", "garibaldi"));
            OrderItem orderItem3 = new OrderItem(new Service(), new Address("cluj", "22", "garibaldi"));

            eventProcessor.Process(new NewOrderItemEvent(orderItem1, order));
            eventProcessor.Process(new NewOrderItemEvent(orderItem2, order));
            eventProcessor.Process(new NewOrderItemEvent(orderItem3, order2));

            Console.WriteLine(order.OrderItems.Count());
            Console.WriteLine(order2.OrderItems.Count());
            Console.ReadKey();
        }
    }
}