using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderStateLengthMustBeLowerThan40Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.State.Length <= 40;
        }
    }
}
