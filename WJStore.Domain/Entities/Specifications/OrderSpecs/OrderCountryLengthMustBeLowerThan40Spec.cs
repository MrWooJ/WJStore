﻿using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderCountryLengthMustBeLowerThan40Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Country.Length <= 40;
        }
    }
}
