using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.CartSpecs
{
    public class CartCountShouldBeGreaterThanZeroSpec : ISpecification<Cart>
    {
        public bool IsSatisfiedBy(Cart cart)
        {
            return cart.Count > 0;
        }
    }
}
