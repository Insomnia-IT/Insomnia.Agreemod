using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.BI.Options
{
    public class FilesConfig
    {
        public string MainPath { get; set; } = "temp";

        public string DownloadPath { get; set; } = "photos";

        public string ExcelFileName { get; set; } = "badges.xlsx";

        public string ZipFileName { get; set; } = "newZip.zip";
    }
}
