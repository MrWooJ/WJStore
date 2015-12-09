using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderFirstNameLengthMustBeLowerThan160Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.FirstName.Length <= 160;
        }
    }
}
