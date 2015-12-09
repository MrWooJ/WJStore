using System;
using WJStore.Domain.Entities.Validations;
using WJStore.Domain.Interfaces.Validation;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities
{
    public class Cart : ISelfValidation
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new CartIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}