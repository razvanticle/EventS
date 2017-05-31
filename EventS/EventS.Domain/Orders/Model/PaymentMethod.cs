using EventS.Domain.SharedKernel;

namespace EventS.Domain.Orders.Model
{
    public class PaymentMethod : ValueObjectBase<PaymentMethod>
    {
        public PaymentMethod(PaymentMethodType type)
        {
            Type = type;
        }

        public PaymentMethodType Type { get; }
    }
}