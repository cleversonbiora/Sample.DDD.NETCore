using AutoMapper;
using TemplateDDD.Domain.Models;
using TemplateDDD.Domain.ViewModel;

namespace TemplateDDD.Domain.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sample, SampleViewModel>();
        }
    }
}
