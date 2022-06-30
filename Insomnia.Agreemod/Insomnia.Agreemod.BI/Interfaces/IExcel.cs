using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Base;

namespace Insomnia.Agreemod.BI.Interfaces
{
    public interface IExcel
    {
        Task<byte[]> ExcelFileGenerate<T>(ExcelModel<T> report, string fileName) where T : ExportModel;
    }
}
