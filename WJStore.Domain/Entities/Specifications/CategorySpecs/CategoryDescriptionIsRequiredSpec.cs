using System;
using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.CategorySpecs
{
    public class CategoryDescriptionIsRequiredSpec : ISpecification<Category>
    {
        public bool IsSatisfiedBy(Category Category)
        {
            return !String.IsNullOrEmpty(Category.Description) && !String.IsNullOrWhiteSpace(Category.Description);
        }
    }
}
