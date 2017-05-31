using EventS.Domain.SharedKernel;
using EventS.Domain.SharedKernel.Model;

namespace EventS.Domain.Orders.Model
{
    public class OrderItem : ValueObjectBase<OrderItem>
    {
        public OrderItem(Service service, Address executionAddress)
        {
            Service = service;
            ExecutionAddress = executionAddress;
        }

        public Address ExecutionAddress { get; }

        public Service Service { get; }
    }

    public class Service
    {
    }
}