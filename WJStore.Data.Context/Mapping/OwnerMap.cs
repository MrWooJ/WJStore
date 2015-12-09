using System.Data.Entity.ModelConfiguration;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Mapping
{
    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            // Primary Key
            HasKey(t => t.OwnerId);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}