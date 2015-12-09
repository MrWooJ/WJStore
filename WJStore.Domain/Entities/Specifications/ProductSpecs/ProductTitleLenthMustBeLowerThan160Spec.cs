using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.ProductSpecs
{
    public class ProductTitleLenthMustBeLowerThan160Spec : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product Product)
        {
            return Product.Title.Trim().Length < 160;
        }
    }
}
