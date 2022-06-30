using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.ViewModels.Output;
using Insomnia.Agreemod.BI.Options;
using Insomnia.Agreemod.BI.Interfaces;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Base;
using System.Net;
using AutoMapper;
using System.IO.Compression;
using Insomnia.Agreemod.Data.Enums;
using Insomnia.Agreemod.General.Expansions;

namespace Insomnia.Agreemod.BI.Services
{
    public class Files : IFiles
    {
        private FilesConfig _config;
        private IExcel _excel;
        private IMapper _mapper;
        private object locker = new object();

        private static (BadgeColor Color, int Count, string position)[] EmptyBadges = new[] {
             (BadgeColor.Green, 40, "Волонтёр"),
             (BadgeColor.Green, 20, "Stage CREW"),
             (BadgeColor.Green, 10, "Прокатчик"),
             (BadgeColor.Green, 4, "Звукорежиссёр FOH"),
             (BadgeColor.Green, 4, "Backline/MON"),
             (BadgeColor.Green, 3, "Художник по свету"),
             (BadgeColor.Green, 4, "Оформители"),
             (BadgeColor.Green, 6, "Смотритель ЦУЭ"),
             (BadgeColor.Yellow, 50, "Свои"),
             (BadgeColor.Purple, 10, "Медлокация"),
             (BadgeColor.Orange, 150, "Музыкант"),
             (BadgeColor.Green, 25, "Музыкальная сцена"),
             (BadgeColor.Blue, 10, ""),
           //  (BadgeColor.Yellow, 150, "Пресса"),
             (BadgeColor.Green, 20, "Стража"),
            };

        public Files(IExcel excel, IMapper mapper)
        {
            _config = new FilesConfig();
            _excel = excel;
            _mapper = mapper;

            CreateDirectory(_config.MainPath);
            CreateDirectory($"{_config.MainPath}/{_config.DownloadPath}");
        }

        public static List<PeopleOutput> AddEmptyBadges()
        {
            var list = new List<PeopleOutput>();

            foreach (var badge in EmptyBadges)
                for (var x = 0; x < badge.Count; x++)
                    list.Add(new PeopleOutput() { Position = badge.position, QR = Guid.NewGuid().ToString(), BadgeColor = badge.Color });

            return list;
        }

        public async Task<Stream> ExportLocations(List<LocationDto> locations)
        {
            await SaveExcel(GetExportModels(locations), "locations");

            return null;
        }

        public async Task<Stream> Export(List<PeopleOutput> members)
        {
            foreach (var member in members.Where(x => x.BadgeColor != BadgeColor.BlueLab).GroupBy(x => x.BadgeColor).Select(x => new
            {
                FileName = x.Key.ToString(),
                Members = x.ToList()
            }))
            {
                await SaveExcel(GetExportModels(member.Members), member.FileName);
            }

            var labMembers = members.Where(x => x.BadgeColor == BadgeColor.BlueLab).ToListOrNull();

            if(labMembers is not null)
                await SaveExcel(GetExportModels(labMembers), "Blue_lab");

           // await SaveExcel(GetExportModels(members), "all");

            foreach(var member in AddEmptyBadges().GroupBy(x => x.BadgeColor).Select(x => new
            {
                FileName = x.Key.ToString(),
                Members = x.ToList()
            }))
            {
                await SaveExcel(GetExportModels(member.Members), member.FileName + "_empty");
            }

            lock (locker)
            {
                return ToArchive(_config.MainPath);
            }
        }

        private ExcelModel<Badge> GetExportModels(List<PeopleOutput> members)
        {
            return new ExcelModel<Badge>()
            {
                Models = _mapper.Map<List<PeopleOutput>, List<Badge>>(members)
            };
        }

        private ExcelModel<LocationExport> GetExportModels(List<LocationDto> locations)
        {
            return new ExcelModel<LocationExport>()
            {
                Models = _mapper.Map<List<LocationDto>, List<LocationExport>>(locations)
            };
        }


        private async Task SaveExcel<T>(ExcelModel<T> members, string fileName) where T : ExportModel
        {
            var excelFile = await _excel.ExcelFileGenerate(members, fileName);

            await File.WriteAllBytesAsync($"{_config.MainPath}/{fileName}.xlsx", excelFile);
        }

        private Stream ToArchive(string path)
        {
            if(File.Exists(_config.ZipFileName))
                File.Delete(_config.ZipFileName);

            ZipFile.CreateFromDirectory(path, _config.ZipFileName);

            var ms = new MemoryStream();

            using (FileStream fs = File.Open(_config.ZipFileName, FileMode.Open))
            {
                fs.CopyTo(ms);
            }

            RemoveDirectory(path);

            return ms;
        }

        private void CreateDirectory(string path)
        {
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void RemoveDirectory(string path)
        {
            if(Directory.Exists(path))
                Directory.Delete(path, true);
        }
    }
}
