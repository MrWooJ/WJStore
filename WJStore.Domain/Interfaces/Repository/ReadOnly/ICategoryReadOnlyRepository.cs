using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository.Common;

namespace WJStore.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICategoryReadOnlyRepository : IReadOnlyRepository<Category>
    {
        Category GetWithProducts(string categoryName);
    }
}