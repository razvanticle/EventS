using System;
using System.Linq.Expressions;

namespace EventS.Domain.SharedKernel.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }

        bool IsSatisfiedBy(T entity);
    }
}