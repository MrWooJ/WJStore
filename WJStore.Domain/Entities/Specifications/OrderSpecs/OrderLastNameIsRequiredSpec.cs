using System;
using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderLastNameIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.LastName) && !String.IsNullOrWhiteSpace(order.LastName);
        }
    }
}
