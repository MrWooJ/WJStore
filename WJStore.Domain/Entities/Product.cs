using System.Collections.Generic;
using WJStore.Domain.Entities.Validations;
using WJStore.Domain.Interfaces.Validation;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities
{
    public class Product : ISelfValidation
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ProductArtUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new ProductIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}