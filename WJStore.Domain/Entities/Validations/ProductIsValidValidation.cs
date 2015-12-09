using WJStore.Domain.Entities.Specifications.ProductSpecs;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities.Validations
{
    public class ProductIsValidValidation : Validation<Product>
    {
        public ProductIsValidValidation()
        {
            base.AddRule(new ValidationRule<Product>(new ProductTitleIsRequiredSpec(), ValidationMessages.TitleIsRequired));
            base.AddRule(new ValidationRule<Product>(new ProductPriceIsRequiredSpec(), ValidationMessages.PriceIsRequired));
            base.AddRule(new ValidationRule<Product>(new ProductPriceMustBeLowerThan100Spec(),ValidationMessages.PriceMustBeBetween001And100));
            base.AddRule(new ValidationRule<Product>(new ProductTitleLenthMustBeLowerThan160Spec(), ValidationMessages.ProductTitleLenthMustBeLowerThan160));
            base.AddRule(new ValidationRule<Product>(new ProductArtUrlLenthMustBeLowerThan1024Spec(), ValidationMessages.ProductArtUrlLengthMustBeLowerThan1024));
        }
    }
}
