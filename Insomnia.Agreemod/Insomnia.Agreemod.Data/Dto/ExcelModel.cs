using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Base;

namespace Insomnia.Agreemod.Data.Dto
{
    public class ExcelModel<T> where T : ExportModel
    {
        public IList<T> Models { get; set; }
    }
}
