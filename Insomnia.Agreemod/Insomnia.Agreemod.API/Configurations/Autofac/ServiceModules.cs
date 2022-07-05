using Autofac;
using AutoMapper;
using Divergic.Configuration.Autofac;
using Insomnia.Agreemod.API.Configurations.AutoMapper;
using Insomnia.Agreemod.BI.Options;
using System;
using Insomnia.Agreemod.BI.Interfaces;
using Insomnia.Agreemod.BI.Services;

namespace Insomnia.Agreemod.API.Configurations.Autofac
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BI.Services.Notion>()
                .As<INotion>();

            builder.RegisterType<ExcelService>()
                .As<IExcel>();

            builder.RegisterType<Files>()
                .As<IFiles>();

            builder.RegisterType<WordService>()
                .As<IWord>();

            builder.RegisterType<FormatterPhotoPeople>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var resolver = new EnvironmentJsonResolver<Config>("appsettings.json", $"appsettings.{env}.json");
            var module = new ConfigurationModule(resolver);

            builder.RegisterModule(module);
        }
    }
}
