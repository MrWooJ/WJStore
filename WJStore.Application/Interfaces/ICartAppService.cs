using System.Collections.Generic;
using WJStore.Application.Interfaces.Common;
using WJStore.Domain.Entities;
using WJStore.Domain.Validation;

namespace WJStore.Application.Interfaces
{
    public interface ICartAppService : IAppService<Cart>
    {
        ValidationResult Remove(IEnumerable<Cart> carts);
        ValidationResult Update(IEnumerable<Cart> carts);
    }
}
