using System.Data.Entity.ModelConfiguration;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            HasKey(t => t.RecordId);

            // Properties
            Property(t => t.CartId)
                .IsRequired();

            Property(t => t.ProductId)
                .IsRequired();

            Property(t => t.Count)
                .IsRequired();

            Property(t => t.DateCreated)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}