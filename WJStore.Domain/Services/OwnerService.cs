using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Common;

namespace WJStore.Domain.Services
{
    public class OwnerService : Service<Owner>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository, IOwnerReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
