using WJStore.Data.Repository.EntityFramework.Common;
using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;

namespace WJStore.Data.Repository.EntityFramework
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
    }
}
