using System.Collections.Generic;
using WJStore.Domain.Entities.Validations;
using WJStore.Domain.Interfaces.Validation;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities
{
    public class Owner : ISelfValidation
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new OwnerIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}