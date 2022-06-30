using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Insomnia.Agreemod.Data;
using Insomnia.Agreemod.Data.Entity;
using System;
using System.Linq;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Base;
using Insomnia.Agreemod.Data.ViewModels.Output;
using Insomnia.Agreemod.Data.Enums;

namespace Insomnia.Agreemod.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PeopleOutput, Badge>()
                .ForMember(x => x.Photo, s => s.MapFrom<FormatterPhotoPeople>());

            CreateMap<LocationDto, LocationExport>()
                .ForMember(x => x.Statuses, s => s.MapFrom(x => String.Join(", ", x.Tags)));

            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
