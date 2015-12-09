using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Common;

namespace WJStore.Domain.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IProductRepository repository, IProductReadOnlyRepository readOnlyRepository) 
            : base(repository, readOnlyRepository)
        {
        }
    }
}
