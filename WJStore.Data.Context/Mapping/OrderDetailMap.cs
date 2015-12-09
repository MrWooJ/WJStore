using System.Data.Entity.ModelConfiguration;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            HasKey(t => t.OrderDetailId);

            // Properties
            Property(t => t.Quantity)
                .IsRequired();

            // Relationship
            HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.OrderId);

            HasRequired(t => t.Product)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.ProductId);

            Ignore(t => t.ValidationResult);
        }
    }
}