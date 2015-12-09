using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderPostalCodeLengthMustBeLowerThan10Spec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.PostalCode.Length <= 10;
        }
    }
}
