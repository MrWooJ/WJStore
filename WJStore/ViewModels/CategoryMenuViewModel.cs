using AutoMapper;
using WJStore.Domain.Entities;

namespace WJStore.ViewModels
{
    public class CategoryMenuViewModel
    {
        public string Name { get; set; }

        public static CategoryMenuViewModel ToViewModel(Category category)
        {
            return Mapper.Map<CategoryMenuViewModel>(category);
        }
    }
}