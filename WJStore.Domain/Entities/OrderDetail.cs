using WJStore.Domain.Entities.Validations;
using WJStore.Domain.Interfaces.Validation;
using WJStore.Domain.Validation;

namespace WJStore.Domain.Entities
{
    public class OrderDetail : ISelfValidation
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new OrderDetailIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
