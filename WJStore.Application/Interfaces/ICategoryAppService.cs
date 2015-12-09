using WJStore.Application.Interfaces.Common;
using WJStore.Domain.Entities;

namespace WJStore.Application.Interfaces
{
    public interface ICategoryAppService : IAppService<Category>
    {
        Category GetWithProducts(string categoryName);
    }
}
