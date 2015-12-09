using System;
using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.CategorySpecs
{
    public class CategoryNameIsRequiredSpec : ISpecification<Category>
    {
        public bool IsSatisfiedBy(Category Category)
        {
            return !String.IsNullOrEmpty(Category.Name) && !String.IsNullOrWhiteSpace(Category.Name);
        }
    }
}
