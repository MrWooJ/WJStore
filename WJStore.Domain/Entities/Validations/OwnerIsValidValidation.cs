using WJStore.Domain.Entities.Specifications.OwnerSpecs;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities.Validations
{
    public class OwnerIsValidValidation : Validation<Owner>
    {
        public OwnerIsValidValidation()
        {
            base.AddRule(new ValidationRule<Owner>(new OwnerNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
        }
    }
}
