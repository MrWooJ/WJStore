using WJStore.Domain.Entities.Specifications.OrderDetailSpecs;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities.Validations
{
    public class OrderDetailIsValidValidation : Validation<OrderDetail>
    {
        public OrderDetailIsValidValidation()
        {
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailQuantityShouldBeGraterThanZeroSpec(), ValidationMessages.QuantityIsInvalid));
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailUnityPriceShouldBeGraterThanZeroSpec(), ValidationMessages.UnityPriceIsInvalid));
        }
    }
}
