using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Common;

namespace WJStore.Domain.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IOrderRepository repository, IOrderReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
