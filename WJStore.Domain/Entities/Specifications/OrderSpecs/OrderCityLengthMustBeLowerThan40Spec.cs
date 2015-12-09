using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderCityLengthMustBeLowerThan40Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.City.Length <= 40;
        }
    }
}
