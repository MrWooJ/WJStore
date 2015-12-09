using AutoMapper;
using WJStore.Domain.Entities;
using WJStore.ViewModels;

namespace WJStore.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoryMenuViewModel, Category>();
        }
    }
}