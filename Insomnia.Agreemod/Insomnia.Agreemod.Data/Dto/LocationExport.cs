using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Base;
using Insomnia.Agreemod.Data.Attributes;

namespace Insomnia.Agreemod.Data.Dto
{
    public class LocationExport : ExportModel
    {
        [HeaderNaming("Название")]
        public string Name { get; set; }

        [HeaderNaming("Кратко")]
        public string ShortName { get; set; }

        [HeaderNaming("Статусы")]
        public string Statuses { get; set; }

        [HeaderNaming("Описание")]
        public string Description { get; set; }
    }
}
