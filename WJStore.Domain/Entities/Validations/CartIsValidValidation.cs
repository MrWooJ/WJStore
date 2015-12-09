using WJStore.Domain.Entities.Specifications.CartSpecs;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities.Validations
{
    public class CartIsValidValidation : Validation<Cart>
    {
        public CartIsValidValidation()
        {
            base.AddRule(new ValidationRule<Cart>(new CartCountShouldBeGreaterThanZeroSpec(), ValidationMessages.NameIsRequired));
        }
    }
}
