using System;
using System.Linq.Expressions;
using EventS.Domain.Orders.Model;
using EventS.Domain.SharedKernel.Specifications;

namespace EventS.Domain.Orders.Specifications
{
    public class CustomerIdSpecification : Specification<Customer>
    {
        private readonly int customerId;

        public CustomerIdSpecification(int customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Customer, bool>> SpecExpression => c => c.Id == customerId;
    }
}