using EventS.Domain.SharedKernel;

namespace EventS.Domain.Orders.Model
{
    public class Customer : Entity<int>
    {
        public Customer(int id) : base(id)
        {
        }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public Name Name { get; set; }
    }
}