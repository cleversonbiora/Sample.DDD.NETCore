

using AutoMapper;
using ModelApi.Domain.Commands.Sample;
using ModelApi.Domain.Models;

namespace ModelApi.Domain.AutoMapper
{
    class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<InsertSampleCommand, Sample>();
        }
    }
}
