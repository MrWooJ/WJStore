using System;
using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderDateShouldBeLowerThanTodaySpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.OrderDate.Date <= DateTime.Today;
        }
    }
}
