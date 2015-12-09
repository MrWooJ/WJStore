using AutoMapper;
using WJStore.Domain.Entities;
using WJStore.ViewModels;

namespace WJStore.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryMenuViewModel>();
        }
    }
}