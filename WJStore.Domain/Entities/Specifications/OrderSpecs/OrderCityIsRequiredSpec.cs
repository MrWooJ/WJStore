using System;
using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderCityIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.City) && !String.IsNullOrWhiteSpace(order.City);
        }
    }
}
