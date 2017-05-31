using System;
using System.Linq.Expressions;
using EventS.Domain.Orders.Model;
using EventS.Domain.SharedKernel.Specifications;

namespace EventS.Domain.Orders.Specifications
{
    public class CustomerEmailSpecification : Specification<Customer>
    {
        private readonly string email;

        public CustomerEmailSpecification(string email)
        {
            this.email = email;
        }

        public override Expression<Func<Customer, bool>> SpecExpression => c => c.Email == email;
    }
}