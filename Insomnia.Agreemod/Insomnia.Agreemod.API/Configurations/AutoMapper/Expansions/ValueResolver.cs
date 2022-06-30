using AutoMapper;
using Insomnia.Agreemod.BI.Options;
using Insomnia.Agreemod.Data.Entity;
using Insomnia.Agreemod.General.Expansions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.ViewModels.Output;
using System.Net;

namespace Insomnia.Agreemod.API.Configurations.AutoMapper
{
    public class FormatterPhotoPeople : IValueResolver<PeopleOutput, Badge, string>
    {
        private readonly IMapper _mapper;
        private FilesConfig _config;

        public FormatterPhotoPeople(IMapper mapper)
        {
            _mapper = mapper;
            _config = new FilesConfig();
        }

        public string Resolve(PeopleOutput source, Badge destination, string result, ResolutionContext context)
        {
            try
            {
                var url = source.Avatar;
                if(String.IsNullOrEmpty(url))
                    return null;

                var extension = url.Split('?')[0].Split('.').Last();

                var name = String.IsNullOrEmpty(source.Name) ? source.Nickname.Replace(':', 't') : source.Name.Replace(':', 't');
                var fileName = $"{name}_{source.Uuid.Split('-')[0]}.{extension}";

                if (!File.Exists(GetFilePath(fileName)))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(url), GetFilePath(fileName));
                    }
                }

                return fileName;
            }
            catch
            {
                return null;
            }
        }

        private string GetFilePath(string fileName) => $"{_config.MainPath}/{_config.DownloadPath}/{fileName}";
    }

}