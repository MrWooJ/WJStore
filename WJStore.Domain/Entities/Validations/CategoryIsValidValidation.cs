using WJStore.Domain.Entities.Specifications.CategorySpecs;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities.Validations
{
    public class CategoryIsValidValidation : Validation<Category>
    {
        public CategoryIsValidValidation()
        {
            base.AddRule(new ValidationRule<Category>(new CategoryNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
            base.AddRule(new ValidationRule<Category>(new CategoryDescriptionIsRequiredSpec(), ValidationMessages.DescriptionIsRequired));
        }
    }
}
