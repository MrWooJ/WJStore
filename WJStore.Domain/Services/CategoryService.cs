using WJStore.Domain.Entities;
using WJStore.Domain.Interfaces.Repository;
using WJStore.Domain.Interfaces.Repository.ReadOnly;
using WJStore.Domain.Interfaces.Service;
using WJStore.Domain.Services.Common;

namespace WJStore.Domain.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryReadOnlyRepository _readOnlyRepository;
        public CategoryService(ICategoryRepository repository, ICategoryReadOnlyRepository readOnlyRepository, ICategoryReadOnlyRepository readOnlyRepository1) 
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
        }

        public Category GetWithProducts(string categoryName)
        {
            return _readOnlyRepository.GetWithProducts(categoryName);
        }
    }
}
