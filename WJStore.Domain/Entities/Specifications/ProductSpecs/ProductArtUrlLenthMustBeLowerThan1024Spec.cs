using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.ProductSpecs
{
    public class ProductArtUrlLenthMustBeLowerThan1024Spec : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product Product)
        {
            return Product.ProductArtUrl.Trim().Length < 1024;
        }
    }
}
