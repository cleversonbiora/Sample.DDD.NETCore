using AutoMapper;
using ModelApi.Domain.Models;
using ModelApi.Domain.ViewModel;

namespace ModelApi.Domain.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sample, SampleViewModel>();
        }
    }
}
