

using AutoMapper;
using TemplateDDD.Domain.Commands.Sample;
using TemplateDDD.Domain.Models;

namespace TemplateDDD.Domain.AutoMapper
{
    class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<InsertSampleCommand, Sample>();
        }
    }
}
