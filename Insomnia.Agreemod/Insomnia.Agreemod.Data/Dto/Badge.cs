using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Base;
using Insomnia.Agreemod.Data.Attributes;

namespace Insomnia.Agreemod.Data.Dto
{
    public class Badge : ExportModel
    {
        [HeaderNaming("имя фамилия")]
        public string Name { get; set; }

        [HeaderNaming("Тип")]
        public string Type { get; set; }
    }
}
