using System.Data.Entity.ModelConfiguration;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductId);

            // Properties
            Property(t => t.Title)
                .HasMaxLength(160)
                .IsRequired();

            Property(t => t.Price)
                .HasPrecision(5, 2) 
                .IsRequired();

            // Relationship
            HasRequired(t => t.Owner)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.OwnerId);

            HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId);

            Ignore(t => t.ValidationResult);
        }
    }
}