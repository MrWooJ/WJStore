using WJStore.Domain.Interfaces.Validation;

namespace WJStore.Domain.Entities.Specifications.ProductSpecs
{
    public class ProductPriceMustBeLowerThan100Spec : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product Product)
        {
            return Product.Price > 0.01m && Product.Price < 100.00m;
        }
    }
}
