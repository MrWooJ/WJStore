using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderPhoneLengthMustBeLowerThan24Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Phone.Length <= 24;
        }
    }
}
