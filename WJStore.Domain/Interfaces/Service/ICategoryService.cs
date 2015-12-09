using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Service.Common;

namespace WJStore.Domain.Interfaces.Service
{
    public interface ICategoryService : IService<Category>
    {
        Category GetWithProducts(string category);
    }
}