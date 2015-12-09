using System.Data.Entity.ModelConfiguration;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            HasKey(t => t.CategoryId);

            // Properties
            Property(t => t.Name)
                .IsRequired();

            Property(t => t.Description)
                .IsOptional();

            Ignore(t => t.ValidationResult);
        }
    }
}