using AutoMapper;
using System;

namespace ModelApi.CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());
                ps.AddProfile(new CommandToDomainMappingProfile());
            });
        }
    }
}
