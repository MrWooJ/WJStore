using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.OwnerSpecs
{
    public class OwnerNameIsRequiredSpec : ISpecification<Owner>
    {
        public bool IsSatisfiedBy(Owner Owner)
        {
            return Owner.Name.Trim().Length > 0;
        }
    }
}
