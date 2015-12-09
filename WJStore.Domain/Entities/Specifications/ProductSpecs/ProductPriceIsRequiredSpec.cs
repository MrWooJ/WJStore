using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.ProductSpecs
{
    public class ProductPriceIsRequiredSpec : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product Product)
        {
            return Product.Price > 0;
        }
    }
}
