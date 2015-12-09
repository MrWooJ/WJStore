using System.Collections.Generic;
using WJStore.Domain.Entities.Validations;
using WJStore.Domain.Interfaces.Validation;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities
{
    public class Category : ISelfValidation
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new CategoryIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
