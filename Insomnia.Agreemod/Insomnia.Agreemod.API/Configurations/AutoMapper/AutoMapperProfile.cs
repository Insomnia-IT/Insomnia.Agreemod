using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Insomnia.Agreemod.Data;
using Insomnia.Agreemod.Data.Entity;
using System;
using System.Linq;

namespace Insomnia.Agreemod.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
