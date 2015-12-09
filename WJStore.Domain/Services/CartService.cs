using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Common;

namespace WJStore.Domain.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(ICartRepository repository, ICartReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
