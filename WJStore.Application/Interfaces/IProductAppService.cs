using System.Collections.Generic;
using WJStore.Application.Interfaces.Common;
using WJStore.Domain.Entities;

namespace WJStore.Application.Interfaces
{
    public interface IProductAppService : IAppService<Product>
    {
        IEnumerable<Product> GetTopSellingProducts(int count);
        
    }
}
