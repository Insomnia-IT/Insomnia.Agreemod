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
        [HeaderNaming("ФИО")]
        public string Name { get; set; }

        [HeaderNaming("Позывной")]
        public string Nickname { get; set; }

        [HeaderNaming("Должность")]
        public string Position { get; set; }

        [HeaderNaming("Фото")]
        public string Photo { get; set; }

        [HeaderNaming("QR")]
        public string QR { get; set; }
    }
}
