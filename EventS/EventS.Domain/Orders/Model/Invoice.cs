using EventS.Domain.SharedKernel;
using EventS.Domain.SharedKernel.Model;

namespace EventS.Domain.Orders.Model
{
    public class Invoice : ValueObjectBase<Invoice>
    {
        public Invoice(Address address)
        {
            Address = address;
        }

        public Address Address { get; }
    }
}